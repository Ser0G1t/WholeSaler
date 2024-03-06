namespace WholeSaler.ApiProvider
{
    public interface ICEIDGApiProvider
    {
        Task<dynamic> checkNip(string nip);
    }
}
