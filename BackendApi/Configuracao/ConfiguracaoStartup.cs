using BackendApi.Dominio.Entidade;

namespace BackendApi.Configuracao
{
    public static class ConfiguracaoStartup
    {
        public static void ConfiguracaoStartupInicial(this IServiceCollection services, IConfiguration configuration)
        {
            //var retornoGlobal = configuration.GetSection("Obj").Get<Global>();


            services.AddSingleton(new Global(
                idTenant: Guid.Parse("0EB5C23C-7086-4825-E42E-08DBC5D47545"),
                idUsuario: Guid.Parse("0EB5C23C-7086-4825-E42E-08DBC5D47545")
            ));


        }

 
    }
}
