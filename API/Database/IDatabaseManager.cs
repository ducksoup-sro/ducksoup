namespace API.Database;

public interface IDatabaseManager : IDisposable
{
    bool CheckConnection();
}