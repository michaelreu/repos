﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WebApp_FlightSimulator.Models
{
    class Client
    {
        IPEndPoint iPEndPoint;
        TcpClient tcpClient;
        Stream stm;
        bool isConnect;
        public Client()
        {
            this.tcpClient = new TcpClient();
            this.isConnect = false;
        }
        //connecting as a client
        public bool connect(string ip, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            tcpClient.Connect(iPEndPoint);
            isConnect = true;
            return true;
        }

        //writing to the flight simulator
        public void write(string command)
        {
            try
            {
                stm = tcpClient.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] bytes = asen.GetBytes(command);
                stm.Write(bytes, 0, bytes.Length);
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("streamException: {0}", e);
            }
        }
        //close the connection
        public void disconnect()
        {
            if (isConnect)
            {
                tcpClient.GetStream().Close();
                tcpClient.Close();
                isConnect = false;
            }
        }
    }
}
