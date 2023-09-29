using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BackendApi.Aplicacao.Profiles.DependenciasDoMapper
{
    public static class ConfiguracaoProfile
    {
        public static void DependenciasDoMapper(this IServiceCollection services)
        {
            ConfigureAutoMapperDependencies(services);
        }

        private static void ConfigureAutoMapperDependencies(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                Injetar(cfg);
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void Injetar(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<TenantProfile>();
            cfg.AddProfile<AuditoriaProfile>();
            cfg.AddProfile<DefeitoProfile>();
            cfg.AddProfile<CheckListTipoProfile>();
            cfg.AddProfile<AtivoTipoProfile>();
            cfg.AddProfile<HabilidadeProfile>();
            cfg.AddProfile<AtivoLocalProfile>();
            cfg.AddProfile<AtivoProfile>();
        }
    }
}
