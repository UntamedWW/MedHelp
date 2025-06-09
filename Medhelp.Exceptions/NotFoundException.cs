using System.Net;

namespace Medhelp.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(string message = "Żądany zasób nie został znaleziony") 
        : base(message, HttpStatusCode.NotFound)
    {
    }
    
    public NotFoundException(string resourceName, object resourceId) 
        : base($"Zasób typu '{resourceName}' o identyfikatorze '{resourceId}' nie został znaleziony", HttpStatusCode.NotFound)
    {
    }
    
    public NotFoundException(string message, Exception innerException) 
        : base(message, innerException, HttpStatusCode.NotFound)
    {
    }
}
