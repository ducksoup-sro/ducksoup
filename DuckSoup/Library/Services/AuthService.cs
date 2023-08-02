using System;
using API;
using API.Database;
using API.Database.DuckSoup;
using API.Services;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;

namespace DuckSoup.Library.Services;

public class AuthService : Service<IAuthService>, IAuthService
{
    private string RefreshSecret { get; }
    private string AccessSecret { get; }
    private long RefreshTokenExpiry { get; }
    private long AccessTokenExpiry { get; }
    private string Issuer { get; }

    public AuthService() : base()
    {
        RefreshSecret = DatabaseHelper.GetSettingOrDefault("AuthRefreshSecret", Guid.NewGuid().ToString());
        AccessSecret = DatabaseHelper.GetSettingOrDefault("AuthAccessSecret", Guid.NewGuid().ToString());
        RefreshTokenExpiry = Convert.ToInt64(DatabaseHelper.GetSettingOrDefault("AuthRefreshTokenExpiry",
            (24 * 7 * 4).ToString()));
        AccessTokenExpiry =
            Convert.ToInt64(DatabaseHelper.GetSettingOrDefault("AuthAccessTokenExpiry", (1 * 5).ToString()));
        Issuer = DatabaseHelper.GetSettingOrDefault("AuthIssuer", "https://ducksoup.cc");
    }

    public string GenerateRefreshToken(User user)
    {
        return JwtBuilder.Create()
            .WithSecret(RefreshSecret)
            .WithAlgorithm(new HMACSHA512Algorithm())
            .AddClaim("iat", Helper.GetCurrentTimeSeconds())
            .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(RefreshTokenExpiry).ToUnixTimeSeconds())
            .AddClaim("iss", Issuer)
            .AddClaim("version", user.tokenVersion)
            .AddClaim("aud", user.userId)
            .Encode();
    }

    public string GenerateAccessToken(User user)
    {
        return JwtBuilder.Create()
            .WithSecret(AccessSecret)
            .WithAlgorithm(new HMACSHA512Algorithm())
            .AddClaim("iat", Helper.GetCurrentTimeSeconds())
            .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(AccessTokenExpiry).ToUnixTimeSeconds())
            .AddClaim("iss", Issuer)
            .AddClaim("version", user.tokenVersion)
            .AddClaim("aud", user.userId)
            .Encode();
    }

    public IAuthPayload? CheckRefreshToken(string refreshToken)
    {
        try
        {
            return JwtBuilder.Create()
                .WithSecret(RefreshSecret)
                .WithAlgorithm(new HMACSHA512Algorithm())
                .MustVerifySignature()
                .Decode<AuthPayload>(refreshToken);
        }
        catch (TokenExpiredException e)
        {
            // Global.Logger.Fatal("TokenExpired: "  + e);
            return null;
        }
        catch (SignatureVerificationException e)
        {
            // Global.Logger.Fatal("SignatureInvalid: "  + e);
            return null;
        }
        catch (InvalidTokenPartsException e)
        {
            // Global.Logger.Fatal("InvalidTokenParts: "  + e);
            return null;
        }
        catch (Exception e)
        {
            // Global.Logger.Fatal("Other: "  + e);
            return null;
        }

        return null;
    }

    public IAuthPayload? CheckAccessToken(string accessToken)
    {
        try
        {
            return JwtBuilder.Create()
                .WithSecret(AccessSecret)
                .WithAlgorithm(new HMACSHA512Algorithm())
                .MustVerifySignature()
                .Decode<AuthPayload>(accessToken);
        }
        catch (TokenExpiredException e)
        {
            // Global.Logger.Fatal("TokenExpired: "  + e);
            return null;
        }
        catch (SignatureVerificationException e)
        {
            // Global.Logger.Fatal("SignatureInvalid: "  + e);
            return null;
        }
        catch (InvalidTokenPartsException e)
        {
            // Global.Logger.Fatal("InvalidTokenParts: "  + e);
            return null;
        }
        catch (Exception e)
        {
            return null;
        }

        return null;
    }
}