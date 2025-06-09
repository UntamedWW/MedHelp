using System.Net;

namespace Medhelp.Exceptions;

public class ForbiddenException : ApiException
{
    public ForbiddenException(string message = "Dostęp zabroniony") 
        : base(message, HttpStatusCode.Forbidden)
    {
    }
    
    public ForbiddenException(string message, Exception innerException) 
        : base(message, innerException, HttpStatusCode.Forbidden)
    {
    }
}
