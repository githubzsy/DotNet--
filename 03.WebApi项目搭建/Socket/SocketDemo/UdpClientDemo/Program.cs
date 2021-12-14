using System;
using System.Net.Sockets;
using System.Text;

namespace UdpClientDemo
{
    /// <summary>
    /// 客户端
    /// </summary>
    class UDPSender
    {
        static void Main(string[] args)
        {
            //创建一个UdpClient对象，0表示系统自动分配发送端口
            //(若同时在本机运行服务端和客户端，则服务端接收和客户端发送需要使用不同端口，否则两个程序使用同一端口将引发冲突)
            UdpClient udpSender = new UdpClient(0);

            //连接到服务端并指定接收端口
            udpSender.Connect("localhost", 11000);

            //连接到子网广播地址并指定接收端口
            //udpSender.Connect("192.168.1.255", 11000);
            //(在使用TCP/IP协议的网络中，主机标识段全为1的IP地址为广播地址，广播地址传送给主机标识段所涉及的所有计算机。
            //例如，对于192.168.1.0(255.255.255.0)网段，其广播地址为192.168.1.255(255的2进制即为11111111)，
            //当发出目的地址为192.168.1.255时，它将分发给该网段上的所有计算机。)

            //把消息转换成字节流发送到服务端
            byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
            udpSender.Send(sendBytes, sendBytes.Length);
            Console.WriteLine("信息已发送");
            //关闭链接
            udpSender.Close();
            Console.ReadKey();
        }
    }
}