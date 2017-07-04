using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
//using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ReseauDLL
{
    public class Reseau
    {
        HashSet<string> _ipClients;
        string _ipServer;
        int _port;
        int _maxPlayer;

        GestionUDP _gestionUDP;
        GestionTCP _gestionTCP;
        public event DataReceive DataReceived;

        public bool IsServer { get { return _ipServer == IPAddress.Loopback.ToString(); } }

        public List<string> Clients
        {
            get { return _gestionTCP.Clients; }
        }

        public Reseau()
        {
            _ipClients = new HashSet<string>();
            _port = 1234;
            _maxPlayer = 4;
        }

        public void Initialize()
        {
            _gestionUDP = new GestionUDP(_port);
            _gestionUDP.FinRechercheServer += _gestionUDP_FinRechercheServer; ;
            _gestionTCP = new GestionTCP(_port);
            _gestionTCP.DataReceived += _gestionTCP_DataReceived;
            
            RechercheServer();
        }

        private void _gestionTCP_DataReceived(string sender, object data)
        {
            Console.WriteLine("Réception data TCP !");
            // Faire des trucs...
            if (IsServer)
            {
                //_gestionUDP.LoopSendBroadcast = false;
            }


            DataReceived(sender, data);

            
        }

        private void _gestionUDP_FinRechercheServer(object sender, RetourUDP_EventArgs e)
        {
            if (e.IpServer != null) // Il y a déjà un server
            {
                Console.WriteLine("server trouvé !");
                _ipServer = e.IpServer;
                // Création TCP Client
                Console.WriteLine("création client TCP !");
                _gestionTCP.CreationClient(_ipServer);
            }
            else // Pas de server, création server
            {
                Console.WriteLine("pas de serveur détecté : création server");
                CreationServer();
                // Création TCP Listener
                Console.WriteLine("création server TCP !");
                //_gestionTCP.CreationServer();
            }
        }

        public void RechercheServer()
        {
            _gestionUDP.RechercheServer();
        }

        public void CreationServer()
        {
            Console.Clear();
            Console.WriteLine("SERVER !");

            _ipServer = IPAddress.Loopback.ToString();
            _gestionTCP.CreationServer();
            _gestionUDP.CreationServer();
        }

        public void SendData(object data)
        {
            _gestionTCP.SendData(data);
        }
        public void SendData(object data, string ipclient)
        {
            _gestionTCP.SendData(data, ipclient);
        }

        public void stopLoop(string s)
        {
            _gestionUDP.LoopSendBroadcast = false;
        }
    }
}
