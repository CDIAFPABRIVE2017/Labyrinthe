using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ReseauDLL
{
    public delegate void DataReceiveTCP(ConnexionClient sender, object data);
    public class ConnexionClient
    {
        const int READ_BUFFER_SIZE = 255;
        TcpClient _client;
        string _clientname;
        private byte[] _readBuffer = new byte[READ_BUFFER_SIZE];

        public string Nom
        {
            get { return _clientname; }
            set { _clientname = value; }
        }

        public event DataReceiveTCP DataReceived;

        public ConnexionClient(TcpClient client)
        {
            _client = client;

            //_clientname = _client.Client.LocalEndPoint.ToString().Split(':')[0];
            _clientname = _client.Client.RemoteEndPoint.ToString().Split(':')[0];

            _client.GetStream().BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(Lecture), null);
            //_client.GetStream().BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DataReceiveing), _client.GetStream());
        }

        private void Lecture(IAsyncResult ar)
        {
            int DataServer;
            //object data;
            string strMessage;
            try
            {
                lock (_client.GetStream())
                {
                    DataServer = _client.GetStream().EndRead(ar);

                    /*BinaryFormatter bf = new BinaryFormatter();
                    data = bf.Deserialize(_client.GetStream());
                    Console.WriteLine("ConnexionClient : DataReceiveing : {0}", data.ToString());*/
                }

                strMessage = Encoding.ASCII.GetString(_readBuffer, 0, DataServer - 1);

                DataReceived(this, strMessage);

                //GestionDataFromServer(data);

                lock (_client.GetStream())
                {
                    _client.GetStream().BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(Lecture), null);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("ConnexionClient : DataReceiveing : ex : {0}", ex.Message);
            }
        }
        private void GestionDataFromServer(object data)
        {
            DataReceived(this, data);
        }

        public void SendData(object data)
        {
            lock (_client.GetStream())
            {
                StreamWriter writer = new StreamWriter(_client.GetStream());
                writer.Write(data.ToString());
                // Make sure all data is sent now.
                writer.Flush();

                /*BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(_client.GetStream(), DateTime.Now);*/
            }
        }
    }
}
