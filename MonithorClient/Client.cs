using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace MonithorClient
{
    public class Client
    {
        [DllExport("_RVExtension@12", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        public static void RVExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;

            performTask(function);

            
        }

        //Perform the task matching the OPcode
        public static void performTask(string str)
        {
            switch (getOP(str))
            {
                
                case (int)MonithorServer.Opcode.Code.SETUP:
                    break;

                case (int)MonithorServer.Opcode.Code.STATUS:
                    break;

                case (int)MonithorServer.Opcode.Code.PLAYERS:
                    break;

                case (int)MonithorServer.Opcode.Code.EVENT:
                    break;

                case (int)MonithorServer.Opcode.Code.COM:
                    break;

                case (int)MonithorServer.Opcode.Code.ACCSETUP:
                    break;
            }
        }

        //Split on comma and return the first word
        public static int getOP(string str)
        {
            int op;
            Int32.TryParse(str.Split(',')[0], out op);
            return op;
        }

        
    }
}
