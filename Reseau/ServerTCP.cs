using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReseauDLL
{
    public delegate void DataReceive(string sender, object data);
    class ServerTCP
    {
        int _port;
        private Hashtable _clients = new Hashtable();
        private TcpListener _listener;
        private Thread _threadEcoute;

        public List<string> Clients { get { return _clients.Keys.OfType<string>().ToList(); } }

        public event DataReceive DataReceived;

        public ServerTCP(int port)
        {
            _port = port;
            _threadEcoute = new Thread(new ThreadStart(Ecoute));
            _threadEcoute.Start();
        }

        private void Ecoute()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, _port);
                _listener.Start();
                do
                {
                    ConnexionClient client = new ConnexionClient(_listener.AcceptTcpClient());
                    client.DataReceived += OnDataReceived;
                } while (true);
            }
            catch (Exception ex)
            {
                // Console.WriteLine("erreur Ecoute server : " + ex.ToString());
            }
        }

        private void OnDataReceived(ConnexionClient sender, object data)
        {
            if (data.ToString() == sender.Nom) ConnectClient(sender, (string)data);
            else DataReceived(sender.Nom, data);
        }

        void ConnectClient(ConnexionClient client, string clientNom)
        {
            if (_clients.Contains(clientNom))
            {
                ReplyToClient(client, "REFUSE"); // avant : new DataTCP(MessageTCP.ECHEC,"REFUSE"),
            }
            else
            {
                client.Nom = clientNom;
                _clients.Add(clientNom, client);
                ReplyToClient(client, "OK"); // avant : new DataTCP(MessageTCP.CONNECT, "ok"), // SendToClients("CHAT|" + client.Nom + " has joined the chat.", client);
            }
        }

        private void SendToClients(ConnexionClient client, object data)
        {
            client.SendData(data);
        }

        private void ReplyToClient(ConnexionClient client, object data)
        {
            ConnexionClient c;
            foreach (DictionaryEntry entry in _clients)
            {
                c = (ConnexionClient)entry.Value;
                if (client.Nom != c.Nom)
                {
                    client.SendData(data);
                }
            }
        }

        void DisconnectClient(ConnexionClient client)
        {
            _clients.Remove(client.Nom); //SendToClients("CHAT|" + client.Nom + " has left the chat.", client);
        }

        void Fermeture()
        {
            _listener.Stop();
        }

        public void SendDataClients(object data)
        {
            //Console.WriteLine("SERVER : SendData _clients ; count : {0}", _clients.Count);
            foreach (DictionaryEntry entry in _clients)
            {
                ((ConnexionClient)entry.Value).SendData(data);
            }
        }

        public void SendDataClient(object data, string clientname)
        {
            foreach (DictionaryEntry entry in _clients)
            {
                if (entry.Key.ToString() == clientname)
                {
                    ((ConnexionClient)entry.Value).SendData(data);
                }
            }
        }
    }
}
