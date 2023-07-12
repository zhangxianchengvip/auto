using System.Reflection;
using Auto.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidator();
        services.AddDomain();
        return services;
    }

    private static void AddValidator(this IServiceCollection services)
    {
        //services.AddTransient<IValidator<request>, requestValidator>();
    }
}