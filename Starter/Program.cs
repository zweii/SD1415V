using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory.Replace("Starter","Peer") + "\\Peer.exe", "Marcelo.txt");
            Process.Start(AppDomain.CurrentDomain.BaseDirectory.Replace("Starter", "Peer") + "\\Peer.exe", "Texto1.txt");
            Process.Start(AppDomain.CurrentDomain.BaseDirectory.Replace("Starter", "Peer") + "\\Peer.exe", "Texto2.txt");
            Console.ReadLine();

        }
    }
}
