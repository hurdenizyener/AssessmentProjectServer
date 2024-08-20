using Application.Common.Logging.Serilog;
using Application.Common.Logging;
using MediatR;
using System.Text.Json;

namespace Application.Common.Pipelines.Logging;

public sealed class LoggingBehavior<TRequest, TResponse>(LoggerServiceBase loggerServiceBase) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ILoggableRequest
{
    private readonly LoggerServiceBase _loggerServiceBase = loggerServiceBase;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters =
        [
            new LogParameter{Type=request.GetType().Name,Value=request},
        ];

        LogDetail logDetail = new()
        {
            MethodName = next.Method.Name,
            Parameters = logParameters,
        };

        _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));

        return await next();
    }
}