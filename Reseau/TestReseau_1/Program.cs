using ReseauDLL;
using System;

namespace TestReseau_1
{
    class Program
    {
        static Reseau rezo;
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT !");
            rezo = new Reseau();
            rezo.Initialize();
            rezo.DataReceived += Rezo_DataReceived;


            
            while (true)
            {
                rezo.SendData(Console.ReadLine());
                if (rezo.Clients != null)
                {
                    foreach (var item in rezo.Clients)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            Console.ReadLine();
        }

        private static void Rezo_DataReceived(string sender, object data)
        {
            rezo.SendData("pouet!");
            Console.WriteLine("sender : {0}", sender.ToString());
            Console.WriteLine("data : {0}", data.ToString());
        }
    }
}
