using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ReseauDLL
{
    public enum MessageTCP
    {
        CONNECT = 0,
        DISCONNECT = 1,
        DATA = 2,
        ECHEC = 3
    };
    public class DataTCP
    {
        MessageTCP _message;
        object _data;
        public MessageTCP Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public DataTCP(MessageTCP message, object data)
        {
            _message = message;
            _data = data;
        }
    }
    /*public class ReceivedDataTCP_EventArgs : EventArgs
    {
        string _ip;
        object _data;

        public string Ip { get { return _ip; } set { _ip = value; } }
        public object Data { get { return _data; } set { _data = value; } }

        public ReceivedDataTCP_EventArgs() { }
        public ReceivedDataTCP_EventArgs(string ip, object data) { _ip = ip; _data = data; }
    }*/

    class GestionTCP
    {
        int _port;
        ServerTCP _server;
        ClientTCP _client;

        public event DataReceive DataReceived;

        public List<string> Clients
        {
            get
            {
                if (_server != null)
                {
                    return _server.Clients;
                }
                else return null;
            }
        }

        public GestionTCP(int port)
        {
            _port = port;
        }

        #region Partie Server
        public void CreationServer()
        {
            _server = new ServerTCP(_port);
            _server.DataReceived += GestionTCPDataReceived;
        }
        #endregion

        #region Partie Client
        public void CreationClient(string ipserver)
        {
            _client = new ClientTCP(_port);
            _client.DataReceived += GestionTCPDataReceived;
            if (_client.Connect(ipserver))
            {
                Console.WriteLine("Connexion réussie...");
                _client.SendData(_client.Nom);
            }
            else
            {
                Console.WriteLine("Echec connexion...");
            }
        }
        #endregion

        private void GestionTCPDataReceived(string sender, object data)
        {
            DataReceived(sender, data);
        }

        public void SendData(object data)
        {
            if (_server != null)
            {
                _server.SendDataClients(data);
            }
            else
            {
                if (_client != null)
                {
                    _client.SendData(data);
                }
                else
                {
                    Console.WriteLine("Problème... ni client, ni server...");
                }
            }
        }

        public void SendData(object data, string ipclient)
        {
            if (_server != null)
            {
                _server.SendDataClient(data, ipclient);
            }
        }

        /*string _ipServer;

        HashSet<TcpClient> _clients;

        TcpClient _server;
        TcpListener _ecouteCLients;

        NetworkStream nstream;

        public delegate void ReceivedDataTCP_EventHandler(object sender, ReceivedDataTCP_EventArgs e);
        public event ReceivedDataTCP_EventHandler ReceivedData;

        public GestionTCP(int port)
        {
            _port = port;
            _clients = new HashSet<TcpClient>();
        }

        #region Partie Server
        bool fini = false;

        public void CreationServer()
        {
            _ecouteCLients = new TcpListener(_port);
            _ecouteCLients.Start();
            EcouteDesClients();
        }

        void EcouteDesClients()
        {
            Console.WriteLine("EcouteDesClients");
            /*while (!fini)
            {*/
        /*_ecouteCLients.BeginAcceptTcpClient(new AsyncCallback(acceptClient), null);
        //}
    }

    private void acceptClient(IAsyncResult ar) // Côté server
    {
        Console.WriteLine("acceptClient");
        TcpClient client = _ecouteCLients.EndAcceptTcpClient(ar);
        if (!_clients.Contains(client))
        {
            _clients.Add(client);
        }
        using (NetworkStream nstream = client.GetStream())
        {
            StreamReader sr = new StreamReader(nstream);
            StreamWriter sw = new StreamWriter(nstream);

            OnReceivedData(new ReceivedDataTCP_EventArgs("VASISTAS?", sr.ReadLine()));

            sw.WriteLine("Server > Client TCP !");
            sw.Flush();

            sr.Close();
            sw.Close();
            /*using (StreamReader sr = new StreamReader(nstream))
            {
                OnReceivedData(new ReceivedDataTCP_EventArgs(client.Client.RemoteEndPoint.ToString(), sr.ReadToEnd()));
            }
            using (StreamWriter sw = new StreamWriter(nstream))
            {
                sw.WriteLine("Server > Clent TCP !");
                sw.Flush();
            }*/
        /*}/*
        _ecouteCLients.BeginAcceptTcpClient(new AsyncCallback(acceptClient), null);
    }
    #endregion

    #region Partie Client
    public void CreationClient(string hostname) // Côté client
    {
        Console.WriteLine("CreationClient");
        _server = new TcpClient(hostname, _port);
        using (nstream = _server.GetStream())
        {
            StreamReader sr = new StreamReader(nstream);
            StreamWriter sw = new StreamWriter(nstream);

            OnReceivedData(new ReceivedDataTCP_EventArgs(hostname, sr.ReadLine()));

            sw.WriteLine("Clent > Server TCP !");
            sw.Flush();

            sr.Close();
            sw.Close();

            /*using (StreamWriter sw = new StreamWriter(nstream))
            {
                sw.WriteLine("Clent > Server TCP !");
                sw.Flush();
            }
            using (StreamReader sr = new StreamReader(nstream))
            {
                OnReceivedData(new ReceivedDataTCP_EventArgs(hostname, sr.ReadToEnd()));
            }*//*
        }
        //_server.Close();
    }
    #endregion

    void OnReceivedData(ReceivedDataTCP_EventArgs e)
    {
        if (ReceivedData != null) ReceivedData(this, e);
    }*/
    }
}
