using API.Database.DuckSoup;

namespace API.Services;

public interface IUserService
{
    User? GetUser(string username);
    User? GetUser(Guid guid);
    List<User> GetUsers();
    void AddUser(User user);
    void RemoveUser(User user);
    void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
}