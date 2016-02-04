using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonithorServer
{
    class Opcode
    {
        enum Code
        {

            //Arma 3 --> this server
            SETUP = 0, //Request setup
            STATUS = 1, //Arma 3 server status
            PLAYERS = 2, //Arma 3 server players


           // this server --> Arma 3
           ACCSETUP = 3, //Accept setup
           COM = 4,  //Send command


        }
    }
}
