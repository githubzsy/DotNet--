using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server
{
    class Program
    {
        static Socket _receiveSocket;
        static void Main(string[] args)
        {
            int port = 8885;
            IPAddress ip = IPAddress.Any;  // 侦听所有网络客户接口的客活动
            _receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议   <br>            ReceiveSocket.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReuseAddress,true);  //有关套接字设置
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            _receiveSocket.Bind(new IPEndPoint(ip, port)); //绑定IP地址和端口号
            _receiveSocket.Listen(10);  //设定最多有10个排队连接请求
            Console.WriteLine("开始监听...");
            AsyncListen();
        }

        /// <summary>
        /// 同步监听
        /// </summary>
        static void SyncListen()
        {
            Socket socket = _receiveSocket.Accept();
            Loop(socket);
        }

        static void AsyncListen()
        {
            AsyncCallback asyncCallback = BeginAcceptCallback;
            // 循环监听
            while (true)
            {
                _receiveSocket.BeginAccept(asyncCallback, _receiveSocket);
            }

        }

        static void BeginAcceptCallback(IAsyncResult ar)
        {
            var socket = ((Socket)ar.AsyncState).EndAccept(ar);
            Loop(socket);
        }

        static void Loop(Socket socket)
        {
            Console.WriteLine($"客户端{socket.RemoteEndPoint}建立连接");
            bool close = false;
            while (!close)
            {
                Console.WriteLine($"开始接收客户端{socket.RemoteEndPoint}的消息...");
                OneAskOneAnswer(socket);
                Console.WriteLine($"是否退出客户端{socket.RemoteEndPoint}(Y)?");
                var c = Console.ReadKey();
                close = (c.Key == ConsoleKey.Y);
                Console.WriteLine();
            }
            socket.Close();
        }




        static void OneAskOneAnswer(Socket socket)
        {
            byte[] receive = new byte[1024];
            socket.Receive(receive);
            Console.WriteLine($"接收到客户端{socket.RemoteEndPoint}的消息：" + Encoding.UTF8.GetString(receive));

            Console.WriteLine($"输入发送给客户端{socket.RemoteEndPoint}的消息,按回车确认:");
            byte[] send = Encoding.UTF8.GetBytes(Console.ReadLine());
            socket.Send(send);
        }
    }
}