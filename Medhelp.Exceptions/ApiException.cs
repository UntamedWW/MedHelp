using System.Net;

namespace Medhelp.Exceptions;

/// <summary>
/// Bazowy wyjątek dla wszystkich wyjątków API
/// </summary>
public abstract class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorCode { get; }

    protected ApiException(string message, HttpStatusCode statusCode, string? errorCode = null) 
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode ?? GetType().Name;
    }

    protected ApiException(string message, Exception innerException, HttpStatusCode statusCode, string? errorCode = null) 
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode ?? GetType().Name;
    }
}
