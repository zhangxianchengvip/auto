using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Auto.Core.AutoDependencyInjection
{
    public static class AutoServiceRegisterServiceCollectionExtension
    {
        public static IServiceCollection ServiceRegister(this IServiceCollection services)
        {
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes(typeof(AutoServiceAttribute), false).Length > 0)
                .ToList().ForEach(impl => { impl.GetInterfaces().ToList().ForEach(i => Add(services, i, impl)); });


            return services;
        }

        private static void Add(IServiceCollection services, Type i, Type impl)
        {
            var attribute = impl.GetCustomAttribute<AutoServiceAttribute>();

            IServiceCollection ser = attribute.Lifetime switch
            {
                ServiceLifetime.Singleton => services.AddSingleton(i, impl),
                ServiceLifetime.Scoped => services.AddScoped(i, impl),
                ServiceLifetime.Transient => services.AddTransient(i, impl),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute.Lifetime))
            };
        }
    }
}