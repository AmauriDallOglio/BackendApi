using BackendApi.Infra.Modelo;
using Microsoft.OpenApi.Models;

namespace BackendApi.Configuracao
{
    internal static class ConfiguracaoApi
    {
        internal static void ConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }

        internal static void ConfiguracaoSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Documentos BackendApi",
                    Version = "v1",
                    Description = "API que fornece os serviços necessários para o sistema."
                });
               
            });
        }

        internal static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }


    }
}
