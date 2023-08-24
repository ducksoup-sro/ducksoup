namespace API.Services;

public interface IAuthPayload
{
    long iat { get; }
    long exp { get; }
    string iss { get; }
    int version { get; }
    Guid aud { get; }
}