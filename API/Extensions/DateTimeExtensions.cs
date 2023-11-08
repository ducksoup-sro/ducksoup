namespace api.Extensions;

public static class DateTimeExtensions
{
    public static long ToUnixTimeMilliseconds(this DateTime dateTime)
    {
        return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            .TotalMilliseconds;
    }
    
    public static long ToUnixTimeSeconds(this DateTime dateTime)
    {
        return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }
}