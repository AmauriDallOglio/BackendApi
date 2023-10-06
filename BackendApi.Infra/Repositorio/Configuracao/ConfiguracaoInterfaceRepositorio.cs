using BackendApi.Dominio.InterfaceRepositorio;
using Microsoft.Extensions.DependencyInjection;

namespace BackendApi.Infra.Repositorio.Configuração
{
    public static class ConfiguracaoInterfaceRepositorio
    {
        public static void DependenciasDoEntity(this IServiceCollection services)
        {
            services.AddInterfaceRepositorio();
        }

        public static IServiceCollection AddInterfaceRepositorio(this IServiceCollection services)
        {
            services.AddTransient<IAtivoRepositorio, AtivoRepositorio>();
            services.AddScoped<IAtivoRepositorio, AtivoRepositorio>();

            services.AddTransient<IAtivoLocalRepositorio, AtivoLocalRepositorio>();
            services.AddScoped<IAtivoLocalRepositorio, AtivoLocalRepositorio>();

            services.AddTransient<IHabilidadeRepositorio, HabilidadeRepositorio>();
            services.AddScoped<IHabilidadeRepositorio, HabilidadeRepositorio>();

            services.AddTransient<IAtivoTipoRepositorio, AtivoTipoRepositorio>();
            services.AddScoped<IAtivoTipoRepositorio, AtivoTipoRepositorio>();

            services.AddTransient<ICheckListTipoRepositorio, CheckListTipoRepositorio>();
            services.AddScoped<ICheckListTipoRepositorio, CheckListTipoRepositorio>();

            services.AddTransient<ITenantRepositorio, TenantRepositorio>();
            services.AddScoped<ITenantRepositorio, TenantRepositorio>();

            services.AddTransient<IAuditoriaRepositorio, AuditoriaRepositorio>();
            services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();

            services.AddTransient<IDefeitoRepositorio, DefeitoRepositorio>();
            services.AddScoped<IDefeitoRepositorio, DefeitoRepositorio>();

            return services;
        }

    }
}
