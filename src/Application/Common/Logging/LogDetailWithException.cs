namespace Application.Common.Logging;

public sealed class LogDetailWithException : LogDetail
{
    public string ExceptionMessage { get; set; }

    public LogDetailWithException()
    {
        ExceptionMessage = string.Empty;
    }

    public LogDetailWithException(string fullName, string methodName, List<LogParameter> parameters, string exceptionMessage) : base(fullName, methodName, parameters)
    {
        ExceptionMessage = exceptionMessage;
    }

}