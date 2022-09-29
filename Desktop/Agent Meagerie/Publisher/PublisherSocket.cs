using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Publisher
{
    class PublisherSocket
    {
        private Socket _socket;
        public bool IsConnected;

        public PublisherSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Send(byte [] data)
        {
            try
            {
                _socket.Send(data);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not send data. {e.Message}");
            }

        }
        public void Connect(string ipAddress, int port)
        {
            //varianta asincrona
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectedCallback, null);
            Thread.Sleep(2000);
        }

        private void ConnectedCallback(IAsyncResult asyncResult)
        {
            if(_socket.Connected)
            {
                Console.WriteLine("Sender connected to Broker.");
            }
            else
            {
                Console.WriteLine("Error:Sender not connected to Broker.");
            }
            IsConnected = _socket.Connected;
        }
    }
} 
