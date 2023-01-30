using API.Database.DuckSoup;

namespace API.Services;

public interface IAuthService
{
    string GenerateRefreshToken(User user);
    string GenerateAccessToken(User user);
    IAuthPayload? CheckRefreshToken(string refreshToken);
    IAuthPayload? CheckAccessToken(string accessToken);
}