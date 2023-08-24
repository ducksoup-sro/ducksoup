using System;
using API.Services;

namespace DuckSoup.Library.Services;

public class AuthPayload : IAuthPayload
{
    public long iat { get; }
    public long exp { get; }
    public string iss { get; }
    public int version { get; }
    public Guid aud { get; }
    
    public AuthPayload(long iat, long exp, string iss, int version, Guid aud)
    {
        this.iat = iat;
        this.exp = exp;
        this.iss = iss;
        this.version = version;
        this.aud = aud;
    }
}