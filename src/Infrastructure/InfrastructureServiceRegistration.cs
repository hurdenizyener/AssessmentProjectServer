using Application.Services.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!));

        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IPositionRepository, PositionRepository>();

        return services;
    }
}