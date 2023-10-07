using BackendApi.Dominio.Entidade;

namespace BackendApi.Configuracao
{
    public static class ConfiguracaoStartup
    {
        public static void ConfiguracaoStartupInicial(this IServiceCollection services, IConfiguration configuration)
        {
            //var retornoGlobal = configuration.GetSection("Obj").Get<Global>();


            services.AddSingleton(new Global(
                idTenant: Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814"), //A31CF8A0-7B4D-EE11-A89E-F0D41578B814
                idUsuario: Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814") //0EB5C23C-7086-4825-E42E-08DBC5D47545
            ));


        }

 
    }
}
