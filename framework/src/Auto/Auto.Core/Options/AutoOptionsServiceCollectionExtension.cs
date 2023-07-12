using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspectCore.Extensions.Reflection;
using Microsoft.Extensions.Options;

namespace Auto.Core.Options
{
    public static class AutoOptionsServiceCollectionExtension
    {
        private const string ConfigureMethodName = "Configure";
        private static readonly MethodInfo? ConfigureMethodInfo;

        static AutoOptionsServiceCollectionExtension()
        {
            ConfigureMethodInfo = typeof(OptionsConfigurationServiceCollectionExtensions).GetMethod
            (
                name: ConfigureMethodName,
                types: new[]
                {
                    typeof(IServiceCollection),
                    typeof(IConfiguration)
                }
            ) ?? throw new ArgumentNullException(nameof(ConfigureMethodInfo));
        }

        public static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
        {
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes().Where(t => t.GetCustomAttribute<AutoOptionsAttribute>() != null))
                .ToList().ForEach(t => t.AddConfigureOptions(services, configuration));

            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration)
        {
            var node = typeof(T).Name;

            return configuration.GetOptions<T>(node);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return configuration.GetSection(node).Get<T>() ?? throw new ArgumentNullException(nameof(T));
        }

        public static T GetOptions<T>(this IServiceProvider serviceProvider, OptionsType optionsType = OptionsType.OptionsSnapshot) where T : class
        {
            return optionsType switch
            {
                OptionsType.Options => serviceProvider.GetRequiredService<IOptionsSnapshot<T>>().Value,
                OptionsType.OptionsSnapshot => serviceProvider.GetRequiredService<IOptionsSnapshot<T>>().Value,
                OptionsType.OptionsMonitor => serviceProvider.GetRequiredService<IOptionsSnapshot<T>>().Value,
                _ => throw new ArgumentOutOfRangeException(nameof(optionsType))
            };
        }

        private static void AddConfigureOptions(this Type type, IServiceCollection services, IConfiguration configuration)
        {
            var typeReflector = type.GetReflector();

            var arrtibute = typeReflector.GetCustomAttribute<AutoOptionsAttribute>();

            string node = arrtibute.Node ?? type.Name;

            ConfigureMethodInfo?.MakeGenericMethod(type).GetReflector().Invoke
            (
                instance: null,
                parameters: new object[]
                {
                    services,
                    configuration.GetSection(node)
                }
            );
        }
    }
}