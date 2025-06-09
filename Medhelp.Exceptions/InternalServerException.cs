using System.Net;

namespace Medhelp.Exceptions;

public class InternalServerException : ApiException
{
    public InternalServerException(string message = "Wystąpił wewnętrzny błąd serwera") 
        : base(message, HttpStatusCode.InternalServerError)
    {
    }
    
    public InternalServerException(string message, Exception innerException) 
        : base(message, innerException, HttpStatusCode.InternalServerError)
    {
    }
}
