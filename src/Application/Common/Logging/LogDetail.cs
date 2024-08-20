namespace Application.Common.Logging;


public class LogDetail
{
    public string FullName { get; set; }
    public string MethodName { get; set; }
    public List<LogParameter> Parameters { get; set; }

    public LogDetail()
    {
        FullName = string.Empty;
        MethodName = string.Empty;
        Parameters = [];
    }

    public LogDetail(string fullName, string methodName, List<LogParameter> parameters)
    {
        FullName = fullName;
        MethodName = methodName;
        Parameters = parameters;
    }
}