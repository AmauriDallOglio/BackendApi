using BackendApi.Aplicacao.Profiles.DependenciasDoMapper;
using BackendApi.Configuracao;
using BackendApi.Infra.Modelo;
using BackendApi.Infra.Repositorio.Configura��o;
using BackendApi.Modelo;
using MediatR;
using BackendApi.Aplicacao.Validador.Configuracao;

var builder = WebApplication.CreateBuilder(args);



var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();


string filePath = "C:\\Amauri\\GitHub\\BackendApiConnection2.txt";
builder.Services.ConfiguracaoStartupInicial(configuration);
builder.Services.ConfigurarDbContext(filePath);
builder.Services.DependenciasDoEntity();
builder.Services.DependenciasDoMapper();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.DependenciasDoValidador();
builder.Services.VersionamentoApi();
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer(); //importante para gerar automaticamente a documenta��o do Swagger com base nos controladores e a��es definidos na API.
builder.Services.AddSwaggerGen(); //respons�vel por gerar a documenta��o do Swagger 
builder.Services.AddCors(); //permitir um dom�nio acessem recursos em outro dom�nio
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //s�o respons�veis por processar comandos e consultas
builder.Services.ConfiguracaoSwaggerGen();
builder.Services.AddCurrentUserService();




var app = builder.Build();

app.ConfiguracaoSwagger();


app.UseMiddleware<ProcessarSolicitacaoRespostaHTTP>(); //criado para lidar com erros e exce��es
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
