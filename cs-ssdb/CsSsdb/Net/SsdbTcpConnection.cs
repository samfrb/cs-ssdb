using System;
using System.Net.Sockets;

namespace CsSsdb.Net
{
    public class SsdbTcpConnection : ISsdbConnection
    {
        private const int ReadBufferSize = 8 * 1024;
        
        private byte[] _readBuffer = new byte[ReadBufferSize];
        private TcpClient _client;
        private NetworkStream _stream;

        public string Host { get; private set; } = "127.0.0.1";
        public int Port { get; private set; } = 8888;

        public SsdbTcpConnection(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public void Connect()
        {
            try
            {
                _client =  new TcpClient();
                _client.Connect(Host, Port);
                _stream = _client.GetStream();
            }
            catch (Exception e)
            {
                //todo throw exception
            }
        }

        public byte[] SendRequest(byte[] request)
        {
            _stream.Write(request, 0, request.Length);
            int bytesRead = _stream.Read(_readBuffer, 0, ReadBufferSize);
            
            byte[] retArray = new byte[bytesRead];
            Array.Copy(_readBuffer, retArray, bytesRead);

            return retArray;
        }
    }

    enum Response
    {
        OK,
        
    }
}