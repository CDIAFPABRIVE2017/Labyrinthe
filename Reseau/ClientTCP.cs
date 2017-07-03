using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ReseauDLL
{
    class ClientTCP
    {
        const int READ_BUFFER_SIZE = 255;
        int _port;
        string _ipServer;

        private byte[] readBuffer = new byte[READ_BUFFER_SIZE];
        string _resultat = "";

        private TcpClient _client;
        private string _clientName;

        public string Nom
        {
            get { return _clientName; }
        }

        public ClientTCP(int port)
        {
            _port = port;
        }

        public event DataReceive DataReceived;

        public bool Connect(string ipserver)
        {
            try
            {
                _ipServer = ipserver;
                _client = new TcpClient(_ipServer, _port);
                _clientName = ((IPEndPoint)_client.Client.LocalEndPoint).Address.ToString();

                _client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(Lecture), null);

                //AttemptLogin(_clientName);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problème connexion server : " + ex.Message.ToString());
                return false;
            }
        }

        private void AttemptLogin(string nomClient)
        {
            SendDataServer(nomClient);
        }

        private void SendDataServer(object data)
        {
            /*BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(_client.GetStream(), data);*/

            StreamWriter writer = new StreamWriter(_client.GetStream());
            writer.Write(data.ToString() + (char)10);
            writer.Flush();
        }
        public void SendData(object data)
        {
            SendDataServer(data);
        }
        private void Lecture(IAsyncResult ar)
        {
            int DataServer;
            try
            {
                DataServer = _client.GetStream().EndRead(ar);
                if (DataServer < 1)
                {
                    _resultat = "Déconnecté";
                }
                else
                {
                    /*BinaryFormatter bf = new BinaryFormatter();
                    GestionDataFromServer(bf.Deserialize(_client.GetStream()));*/
                    string strMessage = Encoding.ASCII.GetString(readBuffer, 0, DataServer);
                    GestionDataFromServer(strMessage);

                    _client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(Lecture), null);
                }
            }
            catch (Exception)
            {
                //throw;
            }

        }

        private void GestionDataFromServer(object data)
        {
            string ip = _client.Client.RemoteEndPoint.ToString().Split(':')[0];
            //DataReceived(_ipServer, data);
            DataReceived(ip, data);
            //DataReceived(null, ip);
        }
    }
}
