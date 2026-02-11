using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_EX
{
    // 클라이언트 드라이브 클래스

    public enum ClientState // 내부 상태 점검용
    {
        Ready,
        Connecting,
        Connected,
        Disconnecting,
        Disconnected,
        Finished
    }

    public enum ConnectionStatus // UI 변경용
    {
        Connecting,
        Connected,
        Disconnecting,
        Disconnected,
        Error
    }

    public class ClientDrive
    {
        private Socket socket;
        private Thread workerThread;
        private Thread receiveThread;
        private volatile ClientState state = ClientState.Ready;

        private readonly object sendLock = new object();

        public event Action<ConnectionStatus> OnStatusChanged;
        public event Action<string> OnMessageReceived;
        public event Action<string> OnLog;

        public string IP { get; private set; }
        public int Port { get; private set; }

        public bool IsConnected => state == ClientState.Connected;

        public void Connect(string host, int port)
        {
            if (state == ClientState.Connected || state == ClientState.Connecting)
            {
                return;
            }

            IP = host;
            Port = port;

            state = ClientState.Connecting;

            if (workerThread == null || !workerThread.IsAlive)
            {
                workerThread = new Thread(RunWorker);
                workerThread.IsBackground = true;
                workerThread.Start();
            }
        }

        private void RunWorker()
        {
            while (state != ClientState.Finished)
            {
                Thread.Sleep(10);

                switch (state)
                {
                    case ClientState.Connecting:
                        TryConnect();
                        break;

                    case ClientState.Connected:
                        if (socket == null || !socket.Connected)
                        {
                            state = ClientState.Disconnecting;
                        }
                        break;

                    case ClientState.Disconnecting:
                        TryDisconnect();
                        break;

                    case ClientState.Disconnected:
                        state = ClientState.Finished;
                        break;

                    case ClientState.Finished:
                        return;
                }
            }
        }

        private void TryConnect()
        {
            try
            {
                OnStatusChanged?.Invoke(ConnectionStatus.Connecting);

                c_Log($"서버({IP}:{Port}) 연결 시도 중...");

                if (socket != null)
                {
                    try
                    {
                        socket.Close();
                    }
                    catch
                    {

                    }
                }

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ep = new IPEndPoint(IPAddress.Parse(IP), Port);

                var result = socket.BeginConnect(ep, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(2000, false);

                if (!success || !socket.Connected)
                {
                    throw new Exception("연결 시간 초과 또는 서버 응답 없음");
                }

                socket.EndConnect(result);
                state = ClientState.Connected;

                c_Log($"서버({IP}:{Port}) 연결됨");
                OnStatusChanged?.Invoke(ConnectionStatus.Connected);

                receiveThread = new Thread(ReceiveLoop);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                c_Log($"연결 실패: {ex.Message}");
                OnStatusChanged?.Invoke(ConnectionStatus.Error);

                state = ClientState.Disconnected;
                state = ClientState.Ready;
            }
        }

        public void Disconnect()
        {
            if (state == ClientState.Connected || state == ClientState.Connecting)
            {
                state = ClientState.Disconnecting;
            }
        }

        private void TryDisconnect()
        {
            try
            {
                OnStatusChanged?.Invoke(ConnectionStatus.Disconnecting);

                if (socket != null)
                {
                    if (socket.Connected)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                    }

                    socket.Close();
                    socket = null;
                }
            }
            catch { }
            finally
            {
                state = ClientState.Disconnected;

                c_Log("서버 연결 종료");
                OnStatusChanged?.Invoke(ConnectionStatus.Disconnected);

                state = ClientState.Ready;
            }
        }

        public void SendMessage(string msg)
        {
            if (!IsConnected)
            {
                c_Log("서버에 연결되어 있지 않습니다.");

                return;
            }

            lock (sendLock)
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    socket.Send(data);
                }
                catch (Exception ex)
                {
                    c_Log($"송신 오류: {ex.Message}");
                }
            }
        }

        public string SendReceive(string message, string checkString, int timeoutMs = 2000)
        {
            if (!IsConnected)
            {
                c_Log("서버에 연결되어 있지 않습니다.");

                return "";
            }

            string received = "";
            ManualResetEvent waitHandle = new ManualResetEvent(false);

            void handler(string msg)
            {
                if (msg.Contains(checkString))
                {
                    received = msg;
                    waitHandle.Set();
                }
            }

            OnMessageReceived += handler;

            SendMessage(message);

            if (!waitHandle.WaitOne(timeoutMs))
            {
                received = "";
            }

            OnMessageReceived -= handler;

            return received;
        }

        private void ReceiveLoop()
        {
            try
            {
                byte[] buffer = new byte[4096];

                while (IsConnected)
                {
                    int n = socket.Receive(buffer);

                    if (n <= 0)
                    {
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buffer, 0, n);

                    OnMessageReceived?.Invoke(msg);
                }
            }
            catch (Exception)
            {
                if (IsConnected)
                {
                    c_Log("서버 연결 끊김");
                }
            }
            finally
            {
                if (IsConnected)
                {
                    Disconnect();
                }
            }
        }

        private void c_Log(string msg)
        {
            OnLog?.Invoke(msg);
        }
    }
}