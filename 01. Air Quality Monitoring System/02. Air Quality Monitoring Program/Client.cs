using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Air_Quality_Monitoring
{
    //클라이언트 드라이브 클래스

    public enum ClientState
    {
        Ready,
        Connecting,
        Connected,
        Disconnecting,
        Disconnected,
        Finished
    }

    public class Client
    {
        private Socket socket;
        private Thread workerThread;
        private Thread receiveThread;
        private volatile ClientState state = ClientState.Ready;

        private const byte STX = 0x02;
        private const byte ETX = 0x03;

        private readonly StringBuilder receiveBuffer = new StringBuilder();
        private readonly object sendLock = new object();

        public event Action<string> OnMessageReceived;
        public event Action<string> OnStatusChanged;

        public string Host { get; private set; }
        public int Port { get; private set; }

        public bool IsConnected => state == ClientState.Connected;

        public void Connect(string host, int port)
        {
            if (state == ClientState.Connected || state == ClientState.Connecting)
            {
                return;
            }

            Host = host;
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
                            state = ClientState.Disconnecting;
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

                socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ep = new IPEndPoint(IPAddress.Parse(Host), Port);

                var result = socket.BeginConnect(ep, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(2000, false);

                if (!success || !socket.Connected)
                {
                    throw new Exception("연결 시간 초과 또는 서버 응답 없음");
                }

                socket.EndConnect(result);
                state = ClientState.Connected;
                OnStatusChanged?.Invoke($"서버({Host}:{Port}) 연결됨");

                receiveThread = new Thread(ReceiveLoop);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"연결 실패: {ex.Message}");
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
                if (socket != null)
                {
                    if (socket.Connected) socket.Shutdown(SocketShutdown.Both);

                    socket.Close();
                    socket = null;
                }
            }
            catch { }
            finally
            {
                state = ClientState.Disconnected;
                OnStatusChanged?.Invoke("서버 연결 종료");

                state = ClientState.Ready;
            }
        }

        public void SendMessage(string msg)
        {
            if (!IsConnected)
            {
                OnStatusChanged?.Invoke("서버에 연결되어 있지 않습니다.");

                return;
            }

            lock (sendLock)
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes($"{(char)STX}{msg}{(char)ETX}");
                    socket.Send(data);
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke($"송신 오류: {ex.Message}");
                }
            }
        }

        public string SendReceive(string message, string checkString, int timeoutMs = 2000)
        {
            if (!IsConnected)
            {
                OnStatusChanged?.Invoke("서버에 연결되어 있지 않습니다.");
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
                    if (n <= 0) break;

                    receiveBuffer.Append(Encoding.UTF8.GetString(buffer, 0, n));

                    ProcessReceivedData();
                }
            }
            catch (Exception)
            {
                if (IsConnected) OnStatusChanged?.Invoke("서버 연결 끊김");
            }
            finally
            {
                if (IsConnected) Disconnect();
            }
        }

        private void ProcessReceivedData()
        {
            while (true)
            {
                string data = receiveBuffer.ToString();
                int stx = data.IndexOf((char)STX);
                int etx = data.IndexOf((char)ETX);

                if (stx >= 0 && etx > stx)
                {
                    string msg = data.Substring(stx + 1, etx - stx - 1);
                    receiveBuffer.Remove(0, etx + 1);
                    OnMessageReceived?.Invoke(msg);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
