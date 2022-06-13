namespace API.ServiceFactory.Exceptions;

public class ServiceTypeMismatchException : Exception
{
    private const string TemplateMessage = "The service {0} is not type of {1}!\n" + "This could be because:\n" +
                                           "a) You typo'd\n" +
                                           "b) A implementation / extension wasn't implemented yet\n";

    public ServiceTypeMismatchException(string arg1, string arg2) : base(string.Format(TemplateMessage, arg1, arg2))
    {
    }

    public ServiceTypeMismatchException(string arg1, string arg2, Exception innerException) : base(
        string.Format(TemplateMessage, arg1, arg2), innerException)
    {
    }
}