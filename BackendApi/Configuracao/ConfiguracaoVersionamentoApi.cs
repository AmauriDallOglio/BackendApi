using BackendApi.Modelo;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Configuracao
{
    public static class ConfiguracaoVersionamentoApi
    {
        public static void VersionamentoApi(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new CustomHeaderApiVersionReader("api-version"),
                    new QueryStringApiVersionReader("api-version")
                );

                options.AssumeDefaultVersionWhenUnspecified = true; // Se o cliente não informar a versão da API, a versão padrão (1.0 neste caso) será usada automaticamente.
                options.DefaultApiVersion = new ApiVersion(1, 0); // Se a versão não for especificada na solicitação, esta será a versão usada.
                options.ReportApiVersions = true; // Versões da API devem ser relatadas nas respostas.
            });
        }
    }
}
