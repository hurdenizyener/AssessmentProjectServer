using Application.Common.Exceptions.Handlers;
using Application.Common.Logging.Serilog;
using Application.Common.Logging;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Application.Common.Exceptions;


public sealed class ExceptionMiddleware(RequestDelegate requestDelegate, LoggerServiceBase loggerServiceBase)
{
    private readonly RequestDelegate _next = requestDelegate;
    private readonly HttpExceptionHandler _exceptionHandler = new();
    private readonly LoggerServiceBase _loggerService = loggerServiceBase;

    //Bütün Kodlara Ayrı Ayrı try-catch yazmıyoruz.Bütün methodlar buradan geçsin.
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);
            await HandlerExceptionAsync(context.Response, exception);
        }

    }

    private Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters =
        [
            new LogParameter
            {
                Type=context.GetType().Name,
                Value=exception.ToString(),

            }
        ];

        LogDetailWithException logDetailWithException = new()
        {
            ExceptionMessage = exception.Message,
            MethodName = _next.Method.Name,
            Parameters = logParameters
        };

        _loggerService.Error(JsonSerializer.Serialize(logDetailWithException));

        return Task.CompletedTask;
    }

    private Task HandlerExceptionAsync(HttpResponse httpResponse, Exception exception)
    {
        httpResponse.ContentType = "application/json";
        _exceptionHandler.Response = httpResponse;
        return _exceptionHandler.HandlerExceptionAsync(exception);
    }

}