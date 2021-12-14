using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServerDemo
{
    /// <summary>
    /// 服务端
    /// </summary>
    class UDPReceive
    {
        static void Main(string[] args)
        {
            //创建一个UdpClient对象，11000为接收端口
            UdpClient udpReceive = new UdpClient(11000);

            //设置远程主机，(IPAddress.Any, 0)代表接收所有IP所有端口发送的数据
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);//或 IPEndPoint remoteIpEndPoint = null;

            //监听数据，接收到数据后，把数据转换成字符串并输出
            byte[] receiveBytes = udpReceive.Receive(ref remoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);
            Console.WriteLine("This is the message you received " + returnData.ToString());
            Console.WriteLine("This message was sent from " + remoteIpEndPoint.Address.ToString() + " on their port number " + remoteIpEndPoint.Port.ToString());

            //关闭连接
            udpReceive.Close();
        }
    }
}