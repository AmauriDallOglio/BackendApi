using BackendApi.Aplicacao.Profiles.DependenciasDoMapper;
using BackendApi.Configuracao;
using BackendApi.Infra.Repositorio.Configuração;
using BackendApi.Modelo;
using MediatR;


var builder = WebApplication.CreateBuilder(args);



var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();


string filePath = "C:\\Amauri\\GitHub\\BackendApiConnection1.txt";
builder.Services.ConfiguracaoStartupInicial(configuration);
builder.Services.ConfigurarDbContext(filePath);
builder.Services.DependenciasDoEntity();
builder.Services.DependenciasDoMapper();
builder.Services.VersionamentoApi();
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer(); //importante para gerar automaticamente a documentação do Swagger com base nos controladores e ações definidos na API.
builder.Services.AddSwaggerGen(); //responsável por gerar a documentação do Swagger 
builder.Services.AddCors(); //permitir um domínio acessem recursos em outro domínio
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //são responsáveis por processar comandos e consultas


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ProcessarSolicitacaoRespostaHTTP>(); //criado para lidar com erros e exceções
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
