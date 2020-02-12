using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace LoadCellTestConsole {
    class Program {
        static void Main(string[] args) {

            Connect("192.168.18.201", 502);

            Console.Read();
        }

        public static void Connect(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}",host);
            s.Connect(IPs[0], port);

            byte[] howdyBytes = Encoding.ASCII.GetBytes("Howdy");
            s.Send(howdyBytes);
            byte[] buffer = new byte[50];
            s.Receive(buffer);
            string replacedData = Encoding.UTF8.GetString(buffer).Replace("z00", "");
            replacedData = replacedData.Substring(1,8);
            replacedData = replacedData.Trim( new Char[] {' '} );
            Console.Write("Load Cell Okunan Değer: "+ replacedData);
            
        }
    }
}
