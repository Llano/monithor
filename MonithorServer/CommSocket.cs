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

namespace MonithorServer
{
    class CommSocket
    {
        public TcpListener _TcpListener { get; set; }
        public bool run { get; set; }
        public CommSocket(IPAddress ip, int port)
        {
            this._TcpListener = new TcpListener(ip, port);
        }

        // Start the TcpListener and assign the connecting clients 
        //to a thread in the threadpool
        public void start()
        {
            this._TcpListener.Start();
            this.run = true;

            while (run) 
            {
                TcpClient client = _TcpListener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(processClient, client);
            }
        }

        public void stop()
        {
            this.run = false;
        }

        public void processClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
        }
    }
}
