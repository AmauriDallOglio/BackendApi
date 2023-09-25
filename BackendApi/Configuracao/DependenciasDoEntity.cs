using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Repositorio;

namespace BackendApi.Configuracao
{
    public static class DependenciasDoEntity
    {
        public static void Injetar(WebApplicationBuilder builder)
        {
            Tenant(builder);
            Auditoria(builder);
            Defeito(builder);
            CheckListTipo(builder);
            AtivoTipo(builder);
            Habilidade(builder);
            AtivoLocal(builder);
        }

        private static void AtivoLocal(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAtivoLocalRepositorio, AtivoLocalRepositorio>();
            builder.Services.AddScoped<IAtivoLocalRepositorio, AtivoLocalRepositorio>();
        }

        private static void Habilidade(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IHabilidadeRepositorio, HabilidadeRepositorio>();
            builder.Services.AddScoped<IHabilidadeRepositorio, HabilidadeRepositorio>();
        }

        private static void AtivoTipo(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAtivoTipoRepositorio, AtivoTipoRepositorio>();
            builder.Services.AddScoped<IAtivoTipoRepositorio, AtivoTipoRepositorio>();
        }

        private static void CheckListTipo(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICheckListTipoRepositorio, CheckListTipoRepositorio>();
            builder.Services.AddScoped<ICheckListTipoRepositorio, CheckListTipoRepositorio>();
        }

        private static void Tenant(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITenantRepositorio, TenantRepositorio>();
            builder.Services.AddScoped<ITenantRepositorio, TenantRepositorio>();
        }

        private static void Auditoria(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAuditoriaRepositorio, AuditoriaRepositorio>();
            builder.Services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();
        }

        private static void Defeito(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IDefeitoRepositorio, DefeitoRepositorio>();
            builder.Services.AddScoped<IDefeitoRepositorio, DefeitoRepositorio>();
        }
    }
}