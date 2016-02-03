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

namespace MonithorServer
{
    public class SignalR
    {

        public string host { get; set; }
        public string url { get; set; }
        public int port { get; set; }
        public IDisposable signalR { get; set; }
        public SignalR(string host, int port)
        {
            this.port = port;
            this.host = host;
            this.url = "http://" + this.host + ":" + this.port;
        }

        public bool start()
        {
            try
            {
                this.signalR = WebApp.Start(this.url);
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
