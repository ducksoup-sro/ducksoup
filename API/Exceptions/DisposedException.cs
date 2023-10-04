namespace API.Exceptions;

public class DisposedException : Exception
{
    private const string TemplateMessage = "The {0} was Disposed isn't loaded yet!\n" + "This could be because:\n" +
                                           "a) Dispose was called\n" +
                                           "b) Providers got nulled\n";

    public DisposedException(string message) : base(string.Format(TemplateMessage, message))
    {
    }

    public DisposedException(string message, Exception innerException) : base(
        string.Format(TemplateMessage, message), innerException)
    {
    }
}