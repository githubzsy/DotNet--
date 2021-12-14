using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static Socket _clientSocket;
        static void Main(string[] args)
        {
            String IP = "127.0.0.1";
            int port = 8885;

            IPAddress ip = IPAddress.Parse(IP);  //将IP地址字符串转换成IPAddress实例
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议
            IPEndPoint endPoint = new IPEndPoint(ip, port); // 用指定的ip和端口号初始化IPEndPoint实例
            _clientSocket.Connect(endPoint);  //与远程主机建立连接


            bool close = false;
            while (!close)
            {
                OneAskOneAnswer(_clientSocket);
                Console.WriteLine("是否退出(Y)?");
                var c = Console.ReadKey();
                close = (c.Key == ConsoleKey.Y);
                Console.WriteLine();
            }
            _clientSocket.Close();  //关闭连接
        }


        static void OneAskOneAnswer(Socket socket)
        {
            Console.WriteLine("请输入要发送的消息,并按回车:");

            byte[] message = Encoding.UTF8.GetBytes(Console.ReadLine());  //通信时实际发送的是字节数组，所以要将发送消息转换字节
            socket.Send(message);
            Console.WriteLine("消息发送完毕, 开始接收消息...");
            byte[] receive = new byte[1024];
            int length = socket.Receive(receive);  // length 接收字节数组长度
            Console.WriteLine("接收消息为：" + Encoding.UTF8.GetString(receive,0,length));
        }
    }
}