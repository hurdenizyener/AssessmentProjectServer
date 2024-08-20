namespace Application.Common.Logging.Serilog.ConfigurationModels;

public sealed class FileLogConfiguration(string filePath)
{
    public string FilePath { get; set; } = filePath;
}
