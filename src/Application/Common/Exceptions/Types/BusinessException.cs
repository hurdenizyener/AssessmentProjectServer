namespace Application.Common.Exceptions.Types;

public sealed class BusinessException(string? message) : Exception(message)
{
}
