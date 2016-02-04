using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonithorServer
{
    public static class Opcode
    {
        public enum Code
        {

            //Arma 3 --> this server
            SETUP = 0, //Request setup
            STATUS = 1, //Arma 3 server status
            PLAYERS = 2, //Arma 3 server players
            EVENT = 3, //A event on the server


            // this server --> Arma 3
            ACCSETUP = 4, //Accept setup
            COM = 5,  //Send command
            ACCCOM = 6 //Command was executed


        }
    }
}
