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

        // Start the TcpListener
        public void start()
        {

            this._TcpListener.Start();
            startAccept();


            

        }

        public void startAccept()
        {
            this._TcpListener.BeginAcceptTcpClient(HandleAsyncConnection, this._TcpListener);
        }


        // Here we handles the client
        private void HandleAsyncConnection(IAsyncResult res)
        {
            startAccept(); //listen for new connections again
            TcpClient client = this._TcpListener.EndAcceptTcpClient(res);
            //proceed

        }


        public void stop()
        {
            this.run = false;
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
