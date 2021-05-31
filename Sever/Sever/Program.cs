﻿using System;
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
        static Socket ReceiveSocket;
        static void Main(string[] args)
        {
            int port =8885;
            IPAddress ip = IPAddress.Any;  // 侦听所有网络客户接口的客活动
            ReceiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议
            ReceiveSocket.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReuseAddress,true);  //有关套接字设置
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            ReceiveSocket.Bind(new IPEndPoint(ip, port)); //绑定IP地址和端口号
            ReceiveSocket.Listen(10);  //设定最多有10个排队连接请求
            Console.WriteLine("建立连接");
            Socket socket = ReceiveSocket.Accept();

            byte[] receive = new byte[1024];
            socket.Receive(receive);
            Console.WriteLine("接收到消息：" + Encoding.ASCII.GetString(receive));
            byte[] send = Encoding.ASCII.GetBytes("Success receive the message,send the back the message");
            socket.Send(send);
            Console.WriteLine("发送消息为：" + Encoding.ASCII.GetString(send));
        }
    }
}