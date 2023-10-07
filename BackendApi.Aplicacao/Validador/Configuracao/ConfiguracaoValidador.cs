using BackendApi.Aplicacao.Aplicacao.AtivoLocal.Command;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BackendApi.Aplicacao.Validador.Configuracao
{
    public static class ConfiguracaoValidador
    {
        public static void DependenciasDoValidador(this IServiceCollection services)
        {
            services.AdicionaInterfaceValidador();
        }

        public static IServiceCollection AdicionaInterfaceValidador(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AtivoLocalInserirCommand>, AtivoLocalInserirValidador>();

            return services;
        }
    }
}

