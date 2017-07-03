using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReseauDLL
{
    public class RetourUDP_EventArgs : EventArgs
    {
        string _ipServer;

        public string IpServer
        {
            get { return _ipServer; }
            set { _ipServer = value; }
        }

        public RetourUDP_EventArgs() { }
        public RetourUDP_EventArgs(string ipserver) { _ipServer = ipserver; }
    }

    class GestionUDP
    {
        int _port;
        string _ipServer;
        bool _loopSendBroadcast = true;
        int _rechercheServerTimeout;
        int _sleepBetweenBroadcast;

        public int RechercheServerTimeout
        {
            get { return _rechercheServerTimeout; }
            set { _rechercheServerTimeout = value; }
        }
        public int SleepBetweenBroadcast
        {
            get { return _sleepBetweenBroadcast; }
            set { _sleepBetweenBroadcast = value; }
        }
        public bool LoopSendBroadcast
        {
            get { return _loopSendBroadcast; }
            set { _loopSendBroadcast = value; }
        }

        public delegate void RetourUDP_EventHandler(object sender, RetourUDP_EventArgs e);
        public event RetourUDP_EventHandler FinRechercheServer;
        public event RetourUDP_EventHandler FinRechercheClients;

        public GestionUDP(int port)
        {
            _port = port;
            _rechercheServerTimeout = 5000;
            _sleepBetweenBroadcast = 500;
        }

        public void RechercheServer()
        {
            new Thread(ThreadRechercheServer).Start();
        }

        void ThreadRechercheServer()
        {
            Console.WriteLine("recherche de serveur UDP...");
            UdpClient client = new UdpClient(_port);
            client.Client.ReceiveTimeout = _rechercheServerTimeout;
            try
            {
                IPEndPoint toutLeMonde = new IPEndPoint(IPAddress.Any, _port);
                client.Receive(ref toutLeMonde);
                _ipServer = toutLeMonde.Address.ToString();
                OnFinRechercheServer(new RetourUDP_EventArgs(_ipServer)); // On renvoie l'ip du server
            }
            catch (Exception)
            {
                if (_ipServer == null) OnFinRechercheServer(new RetourUDP_EventArgs()); // On renvoie rien
            }
            finally
            {
                client.Close();
            }
        }

        public void CreationServer()
        {
            new Thread(LoopEnvoiBroadcast).Start();
        }

        void LoopEnvoiBroadcast()
        {
            Console.WriteLine("Création du serveur UDP...");
            UdpClient server = new UdpClient();
            Console.WriteLine("dbt envoie broadcast");
            do
            {
                IPEndPoint broadcast = new IPEndPoint(IPAddress.Broadcast, _port);
                byte[] data = { byte.MinValue };
                server.Send(data, data.Length, broadcast);
                Thread.Sleep(_sleepBetweenBroadcast);
            } while (_loopSendBroadcast);
            Console.WriteLine("fin envoie broadcast");
            OnFinRechercheClients(new RetourUDP_EventArgs());
            server.Close();
        }

        void OnFinRechercheServer(RetourUDP_EventArgs e)
        {
            if (FinRechercheServer != null) FinRechercheServer(this, e);
        }
        void OnFinRechercheClients(RetourUDP_EventArgs e)
        {
            if (FinRechercheClients != null) FinRechercheClients(this, e);
        }
    }
}
