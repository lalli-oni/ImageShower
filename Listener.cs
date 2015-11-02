using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageShower
{
    class Listener
    {
        private bool _isListening;

        public bool IsListening
        {
            get { return _isListening; }
            set { _isListening = value; }
        }

        public async Task<string> StartListening()
        {
            string url;
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Loopback, 7878);
            using (UdpClient client = new UdpClient(localEndPoint))
            {
                _isListening = true;
                var datagram = await client.ReceiveAsync();
                byte[] buffer = datagram.Buffer;
                return Encoding.ASCII.GetString(buffer);
            }
            return null;
        }
    }
}
