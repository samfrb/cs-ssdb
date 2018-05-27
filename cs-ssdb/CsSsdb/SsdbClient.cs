using CsSsdb.Net;

namespace CsSsdb
{
    public class SsdbClient : ISsdbClient
    {
        private readonly ISsdbConnection _ssdbConnection;
        private readonly IRequestFactory _requestFactory;

        public SsdbClient(ISsdbConnection connection)
        {
            _ssdbConnection = connection;
        }

        public void Run()
        {
            _ssdbConnection.Connect();
        }
        
        public void Set(string key, string value)
        {
            byte[] req = _requestFactory.GetSetRequest();
            _ssdbConnection.SendRequest(req);
        }
    }
}