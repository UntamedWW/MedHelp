using System.Net;

namespace Medhelp.Exceptions;

public class ConflictException : ApiException
{
    public ConflictException(string message = "Wykryto konflikt danych") 
        : base(message, HttpStatusCode.Conflict)
    {
    }
    
    public ConflictException(string resourceName, object resourceId) 
        : base($"Zasób typu '{resourceName}' o identyfikatorze '{resourceId}' już istnieje", HttpStatusCode.Conflict)
    {
    }
    
    public ConflictException(string message, Exception innerException) 
        : base(message, innerException, HttpStatusCode.Conflict)
    {
    }
}
