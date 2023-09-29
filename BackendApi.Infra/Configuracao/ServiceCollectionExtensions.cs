using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace BackendApi.Infra.Configuracao
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction)
            => AddAutoMapperClasses(services, (sp, cfg) => configAction?.Invoke(cfg), null);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
            => AddAutoMapperClasses(services, null, assemblies);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction, params Assembly[] assemblies)
            => AddAutoMapperClasses(services, (sp, cfg) => configAction?.Invoke(cfg), assemblies);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction, params Assembly[] assemblies)
            => AddAutoMapperClasses(services, configAction, assemblies);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            => AddAutoMapperClasses(services, (sp, cfg) => configAction?.Invoke(cfg), assemblies, serviceLifetime);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            => AddAutoMapperClasses(services, configAction, assemblies, serviceLifetime);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            => AddAutoMapperClasses(services, null, assemblies, serviceLifetime);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
            => AddAutoMapperClasses(services, null, profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction, params Type[] profileAssemblyMarkerTypes)
            => AddAutoMapperClasses(services, (sp, cfg) => configAction?.Invoke(cfg), profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction, params Type[] profileAssemblyMarkerTypes)
            => AddAutoMapperClasses(services, configAction, profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction,
            IEnumerable<Type> profileAssemblyMarkerTypes, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            => AddAutoMapperClasses(services, (sp, cfg) => configAction?.Invoke(cfg), profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly), serviceLifetime);

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction,
            IEnumerable<Type> profileAssemblyMarkerTypes, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            => AddAutoMapperClasses(services, configAction, profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly), serviceLifetime);

        private static IServiceCollection AddAutoMapperClasses(IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction,
            IEnumerable<Assembly> assembliesToScan, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            if (configAction != null)
            {
                services.AddOptions<MapperConfigurationExpression>()
                    .Configure<IServiceProvider>((options, sp) => configAction(sp, options));
            }

            var assembliesToScanArray = assembliesToScan as Assembly[] ?? assembliesToScan?.ToArray();

            if (assembliesToScanArray != null && assembliesToScanArray.Length > 0)
            {
                var allTypes = assembliesToScanArray
                    .Where(a => !a.IsDynamic && a != typeof(Mapper).Assembly)
                    .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
                    .SelectMany(a => a.DefinedTypes)
                    .ToArray();

                services.Configure<MapperConfigurationExpression>(options => options.AddMaps(assembliesToScanArray));

                var openTypes = new[]
                {
                    typeof(IValueResolver<,,>),
                    typeof(IMemberValueResolver<,,,>),
                    typeof(ITypeConverter<,>),
                    typeof(IValueConverter<,>),
                    typeof(IMappingAction<,>)
                };
                foreach (var type in openTypes.SelectMany(openType => allTypes
                    .Where(t => t.IsClass
                        && !t.IsAbstract
                        && t.AsType().ImplementsGenericInterface(openType))))
                {
                    // use try add to avoid double-registration
                    services.TryAddTransient(type.AsType());
                }
            }

            // Just return if we've already added AutoMapper to avoid double-registration
            if (services.Any(sd => sd.ServiceType == typeof(IMapper)))
                return services;

            services.AddSingleton<IConfigurationProvider>(sp =>
            {
                // A mapper configuration is required
                var options = sp.GetRequiredService<IOptions<MapperConfigurationExpression>>();
                return new MapperConfiguration(options.Value);
            });

            services.Add(new ServiceDescriptor(typeof(IMapper),
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService), serviceLifetime));

            return services;
        }

        private static bool ImplementsGenericInterface(this Type type, Type interfaceType)
            => type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => @interface.IsGenericType(interfaceType));

        private static bool IsGenericType(this Type type, Type genericType)
            => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}
