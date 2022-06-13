namespace API.ServiceFactory.Exceptions;

public class ServiceNotRegisteredException : Exception
{
    private const string TemplateMessage = "The {0} service isn't loaded yet!\n" + "This could be because:\n" +
                                           "a) {0} failed to enable\n" +
                                           "b) {0} was not registered\n" +
                                           "c) You're trying to load {0} before it got registered\n";

    public ServiceNotRegisteredException(string message) : base(string.Format(TemplateMessage, message))
    {
    }

    public ServiceNotRegisteredException(string message, Exception innerException) : base(
        string.Format(TemplateMessage, message), innerException)
    {
    }
}