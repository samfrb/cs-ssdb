namespace CsSsdb
{
    public interface IRequestFactory
    {
        byte[] GetSetRequest(params byte[][] args);
    }
}