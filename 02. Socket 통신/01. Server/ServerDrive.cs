using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_EX
{
    // 서버 드라이브 클래스

    public class ServerDrive
    {
        private Socket listener;
        private Thread listenThread;

        private readonly List<Socket> clients = new List<Socket>();
        private readonly object lockObj = new object();

        public event Action<string> OnLog;
        public event Action<int> OnClientCountChanged;

        public bool IsRunning { get; private set; }

        public int ConnectedClientCount
        {
            get
            {
                lock (lockObj)
                {
                    return clients.Count;
                }
            }
        }

        public void Connect(string ip, int port)
        {
            if (IsRunning)
            {
                s_Log("이미 서버가 실행 중입니다.");

                return;
            }

            try
            {
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                listener.Listen(10);

                IsRunning = true;

                listenThread = new Thread(ListenLoop);
                listenThread.IsBackground = true;
                listenThread.Start();

                s_Log($"서버 시작: {ip}: {port}");
            }
            catch (Exception ex)
            {
                s_Log($"서버 시작 실패: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            if (!IsRunning)
            {
                return;
            }

            IsRunning = false;

            try
            {
                listener.Close();
            }
            catch
            {

            }

            lock (lockObj)
            {
                foreach (var cli in clients)
                {
                    try
                    {
                        cli.Close();
                    }
                    catch
                    {

                    }
                }

                clients.Clear();
            }

            s_Log("서버 종료");
        }

        private void ListenLoop()
        {
            while (IsRunning)
            {
                try
                {
                    Socket client = listener.Accept();

                    lock (lockObj)
                    {
                        clients.Add(client);
                    }

                    OnClientCountChanged?.Invoke(ConnectedClientCount);

                    s_Log($"클라이언트 접속: {client.RemoteEndPoint}");

                    Thread recvThread = new Thread(() => ReceiveLoop(client));
                    recvThread.IsBackground = true;
                    recvThread.Start();
                }
                catch
                {
                    if (!IsRunning)
                    {
                        return;
                    }
                }
            }
        }

        private void ReceiveLoop(Socket client)
        {
            try
            {
                byte[] buffer = new byte[4096];

                while (IsRunning && client.Connected)
                {
                    int n = client.Receive(buffer);

                    if (n <= 0)
                    {
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buffer, 0, n);

                    s_Log($"[수신]: {msg}");
                }
            }
            catch { }
            finally
            {
                lock (lockObj)
                {
                    clients.Remove(client);
                }

                if (IsRunning)
                {
                    OnClientCountChanged?.Invoke(ConnectedClientCount);

                    s_Log("클라이언트 연결 종료");
                }

                client.Close();
            }
        }

        public void SendMessage(string msg)
        {
            if (!IsRunning)
            {
                return;
            }

            if (ConnectedClientCount == 0)
            {
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(msg);

            lock (lockObj)
            {
                foreach (var cli in clients.ToArray())
                {
                    try
                    {
                        cli.Send(data);
                    }
                    catch
                    {
                        clients.Remove(cli);
                    }
                }
            }

            s_Log($"[송신]: {msg}");
        }

        private void s_Log(string msg)
        {
            OnLog?.Invoke(msg);
        }
    }
}
