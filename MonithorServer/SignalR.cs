using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Host.HttpListener;
using System.Diagnostics;

namespace MonithorServer
{
    public class SignalR
    {

        public string host { get; set; }
        public string url { get; set; }
        public int port { get; set; }
        public IDisposable signalR { get; set; }
        public bool running { get; set; }
        public SignalR(string host, int port)
        {
            this.port = port;
            this.host = host;
            this.url = "http://" + this.host + ":" + this.port;
            this.running = false;
        }

        // Check whether the signalR server is running or not
        public bool isRunning()
        {
            return this.running;
        }

        //Send message to a specific group on the website
        public void sendMessageToGroup(string groupID, string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.Group(groupID).addMessage(message);
        }

        // Start SignalR server
        public bool start()
        {
            try
            {
                this.signalR = WebApp.Start(this.url);
                this.running = true;
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Stop SignalR server
        public void stop()
        {
            this.signalR.Dispose();
            this.running = false;
        }

    }
}
