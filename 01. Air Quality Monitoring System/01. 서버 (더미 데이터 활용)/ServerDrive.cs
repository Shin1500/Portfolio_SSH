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

        private const byte STX = 0x02;
        private const byte ETX = 0x03;

        private Dictionary<Socket, bool> streamingClients = new Dictionary<Socket, bool>();

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

                StringBuilder sb = new StringBuilder();

                while (IsRunning && client.Connected)
                {
                    int n = client.Receive(buffer);

                    if (n <= 0)
                    {
                        break;
                    }

                    sb.Append(Encoding.UTF8.GetString(buffer, 0, n));

                    while (true)
                    {
                        string data = sb.ToString();

                        int stx = data.IndexOf((char)STX);
                        int etx = data.IndexOf((char)ETX);

                        if (stx >= 0 && etx > stx)
                        {
                            string msg = data.Substring(stx + 1, etx - stx - 1);

                            sb.Remove(0, etx + 1);

                            HandleCommand(client, msg);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch { }
            finally
            {
                lock (lockObj)
                {
                    clients.Remove(client);

                    streamingClients.Remove(client);
                }

                if (IsRunning)
                {
                    OnClientCountChanged?.Invoke(ConnectedClientCount);

                    s_Log("클라이언트 연결 종료");
                }

                client.Close();
            }
        }

        private void HandleCommand(Socket client, string cmd)
        {
            s_Log($"[수신] {cmd}");

            switch (cmd)
            {
                case "KICK":
                    Send(client, "ACK");
                    break;

                case "Get_Data":
                    StartStreaming(client);
                    break;

                case "STOP":
                    StopStreaming(client);
                    break;
            }
        }

        private void Send(Socket client, string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes($"{(char)STX}{msg}{(char)ETX}");
            client.Send(data);

            s_Log($"송신: {msg}");
        }

        private void StartStreaming(Socket client)
        {
            lock (lockObj)
            {
                if (streamingClients.ContainsKey(client))
                {
                    return;
                }

                streamingClients[client] = true;
            }

            new Thread(() =>
            {
                Random rnd = new Random();

                while (IsRunning && client.Connected)
                {
                    lock (lockObj)
                    {
                        if (!streamingClients.ContainsKey(client))
                            break;
                    }

                    // 초기 설정값
                    /*
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(20, 30)}," +      // 온도
                                  $"{rnd.Next(40, 70)}," +      // 습도
                                  $"{rnd.Next(18, 22)}," +      // 산소
                                  $"{rnd.Next(400, 800)}," +    // 이산화탄소
                                  $"{rnd.Next(5, 50)}," +       // 미세먼지
                                  $"{rnd.Next(1, 25)}";         // 초미세먼지
                    */

                    // 좋음
                    /*
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(0, 25)}," +      // 온도
                                  $"{rnd.Next(0, 60)}," +      // 습도
                                  $"{rnd.Next(21, 100)}," +      // 산소
                                  $"{rnd.Next(0, 800)}," +    // 이산화탄소
                                  $"{rnd.Next(0, 30)}," +       // 미세먼지
                                  $"{rnd.Next(0, 15)}";         // 초미세먼지
                    */

                    // 보통
                    /*
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(25, 27)}," +      // 온도
                                  $"{rnd.Next(60, 70)}," +      // 습도
                                  $"{rnd.Next(19, 21)}," +      // 산소
                                  $"{rnd.Next(800, 1000)}," +    // 이산화탄소
                                  $"{rnd.Next(30, 80)}," +       // 미세먼지
                                  $"{rnd.Next(15, 35)}";         // 초미세먼지
                    */

                    // 나쁨
                    /*
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(27, 30)}," +      // 온도
                                  $"{rnd.Next(70, 80)}," +      // 습도
                                  $"{rnd.Next(18, 20)}," +      // 산소
                                  $"{rnd.Next(1000, 1500)}," +    // 이산화탄소
                                  $"{rnd.Next(80, 150)}," +       // 미세먼지
                                  $"{rnd.Next(35, 75)}";         // 초미세먼지
                    */

                    // 매우나쁨
                    /*
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(30, 40)}," +      // 온도
                                  $"{rnd.Next(80, 90)}," +      // 습도
                                  $"{rnd.Next(0, 18)}," +      // 산소
                                  $"{rnd.Next(1500, 2000)}," +    // 이산화탄소
                                  $"{rnd.Next(150, 200)}," +       // 미세먼지
                                  $"{rnd.Next(75, 100)}";         // 초미세먼지
                    */

                    // 랜덤
                    string data = $"{DateTime.Now:HH:mm:ss}," +
                                  $"{rnd.Next(0, 40)}," +      // 온도
                                  $"{rnd.Next(0, 100)}," +      // 습도
                                  $"{rnd.Next(0, 100)}," +      // 산소
                                  $"{rnd.Next(0, 2000)}," +    // 이산화탄소
                                  $"{rnd.Next(0, 200)}," +       // 미세먼지
                                  $"{rnd.Next(0, 100)}";         // 초미세먼지

                    Send(client, $"DATA,{data}");
                    Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }

        private void StopStreaming(Socket client)
        {
            lock (lockObj)
            {
                if (streamingClients.ContainsKey(client))
                {
                    streamingClients.Remove(client);
                }
            }

            Send(client, "STOP_ACK");
            s_Log("스트리밍 중지");
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

            byte[] data = Encoding.UTF8.GetBytes($"{(char)STX}{msg}{(char)ETX}");

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
