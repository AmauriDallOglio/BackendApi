using BackendApi.Aplicacao.Profiles.DependenciasDoMapper;
using BackendApi.Configuracao;
using BackendApi.Infra.Repositorio.Configura��o;
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
builder.Services.AddEndpointsApiExplorer(); //importante para gerar automaticamente a documenta��o do Swagger com base nos controladores e a��es definidos na API.
builder.Services.AddSwaggerGen(); //respons�vel por gerar a documenta��o do Swagger 
builder.Services.AddCors(); //permitir um dom�nio acessem recursos em outro dom�nio
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //s�o respons�veis por processar comandos e consultas


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ProcessarSolicitacaoRespostaHTTP>(); //criado para lidar com erros e exce��es
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
