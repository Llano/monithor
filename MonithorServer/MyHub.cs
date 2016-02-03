using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;

namespace MonithorServer
{
    public class MyHub : Hub
    {
        // This method is called by the client from the website
        public void Send(String cmd)
        {
            //Command.addCommand(cmd);
            //Clients.All.addMessage(message);
            //Clients.Group(group).addMessage(message);


        }

        //Website-client calls this method to join a specific group
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }
    }
}
