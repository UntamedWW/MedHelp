using System.Net;

namespace Medhelp.Exceptions;

public class BadRequestException : ApiException
{
    public BadRequestException(string message = "Nieprawidłowe żądanie") 
        : base(message, HttpStatusCode.BadRequest)
    {
    }
    
    public BadRequestException(string message, Exception innerException) 
        : base(message, innerException, HttpStatusCode.BadRequest)
    {
    }
}
