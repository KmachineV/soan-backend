namespace soan_backend.Services.Interfaces
{
    public interface IPasswordHashing
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}
