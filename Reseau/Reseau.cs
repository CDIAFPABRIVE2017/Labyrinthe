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

        public bool IsServer { get { return _ipServer == IPAddress.Loopback.ToString(); } }
        public List<string> Clients { get { return _gestionTCP.Clients; } }

        public event DataReceive DataReceived;
        private void OnDataReceived(string sender, object data) { if (DataReceived != null) DataReceived(sender, data); }

        public Reseau()
        {
            _ipClients = new HashSet<string>();
            _port = 1234;
            _maxPlayer = 4;
        }

        public void Initialize()
        {
            _gestionUDP = new GestionUDP(_port);
            _gestionUDP.FinRechercheServer += UDP_FinRechercheServer; ;
            _gestionTCP = new GestionTCP(_port);
            _gestionTCP.DataReceived += TCP_DataReceived;
            
            RechercheServer();
        }

        private void TCP_DataReceived(string sender, object data)
        {
            //Console.WriteLine("Réception data TCP !");
            OnDataReceived(sender, data); // Faire des trucs..
        }

        private void UDP_FinRechercheServer(string ipserver)
        {
            if (ipserver != null) // Il y a déjà un server
            {
                //Console.WriteLine("server trouvé ! création client TCP !");
                _ipServer = ipserver;
                _gestionTCP.CreationClient(_ipServer); // Création TCP Client
            }
            else // Pas de server, création server
            {
                //Console.WriteLine("pas de serveur détecté : création server");
                CreationServer(); // Création TCP Listener
            }
        }

        public void RechercheServer() { _gestionUDP.RechercheServer(); }

        public void CreationServer()
        {
            /*Console.Clear();
            Console.WriteLine("SERVER !");*/
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
