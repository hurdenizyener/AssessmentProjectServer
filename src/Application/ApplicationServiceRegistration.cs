using Application.Common.Logging.Serilog.Loggers;
using Application.Common.Logging.Serilog;
using Application.Common.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.Common.Pipelines.Validation;
using Application.Common.Pipelines.Logging;
using Application.Common.Pipelines.Caching;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddSingleton<LoggerServiceBase, FileLogger>();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

        });


        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
     this IServiceCollection services,
     Assembly assembly,
     Type type,
     Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        //assembly içerisinde subclass olarak (BaseBuninessRule) bul ve onları  LifeCycle la ekle.
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }

}