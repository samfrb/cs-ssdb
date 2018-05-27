namespace CsSsdb.Net
{
    public interface ISsdbConnection
    {
        void Connect();
        byte[] SendRequest(byte[] request);
    }
}