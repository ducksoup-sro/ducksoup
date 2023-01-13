using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using API.Database.DuckSoup;
using API.Database.Services;

namespace DuckSoup.Library.Database.Services;

public class UserService : Service<IUserService>, IUserService 
{
    public User GetUser(string username)
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.FirstOrDefault(c => c.username == username, null);
    }

    public User GetUser(Guid guid)
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.FirstOrDefault(c => c.userId == guid, null);
    }

    public List<User> GetUsers()
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.ToList();
    }

    public void AddUser(User user)
    {
        using var db = new API.Database.Context.DuckSoup();
        db.Users.Update(user);
        db.SaveChanges();
    }

    public void RemoveUser(User user)
    {
        using var db = new API.Database.Context.DuckSoup();
        db.Users.Remove(user);
        db.SaveChanges();
    }

    public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}