using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using API.Database.DuckSoup;
using API.Services;

namespace DuckSoup.Library.Services;

public class UserService : Service<IUserService>, IUserService
{
    public User GetUser(string username)
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.Where(c => c.username == username).ToList().FirstOrDefault();
    }

    public User GetUser(Guid guid)
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.Where(c => c.userId == guid).ToList().FirstOrDefault();
    }

    public List<User> GetUsers()
    {
        using var db = new API.Database.Context.DuckSoup();
        return db.Users.ToList();
    }

    public void AddUser(User user)
    {
        using var db = new API.Database.Context.DuckSoup();
        var tempUser = GetUser(user.userId);
        if (tempUser == null)
            db.Users.Add(user);
        else
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
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}