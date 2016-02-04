using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Diagnostics;

namespace MonithorServer
{
    public class CommSocket
    {
        public TcpListener _TcpListener { get; set; }
        public bool run { get; set; }
        public CommSocket(IPAddress ip, int port)
        {
            this._TcpListener = new TcpListener(ip, port);
            this.run = false;
        }

        // Start the TcpListener and assign the connecting clients 
        //to a thread in the threadpool
        public void start()
        {
            Thread t = new Thread(() =>
            {
                this._TcpListener.Start();
                this.run = true;

                while (run)
                {

                    TcpClient client = _TcpListener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(processClient, client);
                }

                this._TcpListener.Stop();
            });
            t.IsBackground = true; //We don't want the thread to keep running after application exit
            t.Start();
            
        }

        public bool isRunning()
        {
            return run;
        }

        public void stop()
        {
            this.run = false;
        }

        // Here we handles the client
        public void processClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            Debug.Write("Client connected");
            
        }

        //Send message to a client
        public void sendMessageClient(TcpClient tcpClient, string message)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

    }
}
