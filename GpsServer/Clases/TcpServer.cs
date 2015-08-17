using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GpsServer.Clases
{
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();

                // client found.
                // create a thread to handle communication
                Thread t = new Thread(HandleClient);
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

         
            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            NetworkStream sReader = client.GetStream();
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested

            Boolean bClientConnected = true;
            String sData = null;

            int i;
            Byte[] bytes = new Byte[256];
            while ((i = sReader.Read(bytes, 0, bytes.Length)) != 0)
            {
                // reads from stream
                sData = Encoding.ASCII.GetString(bytes, 0, i);
                sData = sData.ToUpper();
                if (sData.Substring(0, 2) == "##")
                {
                    //SalidaMonitor("Paquete recibido: LOGON REQUEST del equipo");


                    string ack_packet = "LOAD";
                    byte[] msg = Encoding.ASCII.GetBytes(ack_packet);
                    sReader.Write(msg, 0, msg.Length);
                    // return;
                }

                // Proces
                // byte[] msg = System.Text.Encoding.ASCII.GetBytes(sData);
                // shows content on the console.
                //Console.WriteLine("Paquete recibido " + DateTime.Now + ": " + sData);
                //LogFile logger = new LogFile();
                //logger.MyLogFile("Mensaje", string.Format("Paquete recibido {0}: {1}", DateTime.Now, sData));


                //sReader.Write(msg, 0, msg.Length);

                // to write something back.
                // sWriter.WriteLine("Meaningfull things here");
                // sWriter.Flush();
            }
        }

    }
}