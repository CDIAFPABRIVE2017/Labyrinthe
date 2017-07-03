using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReseauDLL;
using System.Threading;

namespace TestReseau_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SERVER !");
            Thread.Sleep(1000);
            Reseau r = new Reseau();
            r.Initialize();
            r.CreationServer();

            while (true)
            {
                r.SendData(Console.ReadLine());
            }

            //r.stopLoop(Console.ReadLine());

            Console.ReadLine();
        }
    }
}
