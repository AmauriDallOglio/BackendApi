using AutoMapper;
using BackendApi.Configuracao;
using BackendApi.Infra.Context;
using BackendApi.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = ApiVersionReader.Combine(
       new CustomHeaderApiVersionReader("api-version"),
       new QueryStringApiVersionReader("api-version")
   );
    options.AssumeDefaultVersionWhenUnspecified = true; // Essa linha indica que, se a vers�o da API n�o for especificada na solicita��o, a vers�o padr�o ser� assumida. Isso significa que se o cliente n�o informar a vers�o da API, a vers�o padr�o (1.0 neste caso) ser� usada automaticamente.
    options.DefaultApiVersion = new ApiVersion(1, 0); //Define a vers�o padr�o da API. Como mencionado anteriormente, se a vers�o n�o for especificada na solicita��o, esta ser� a vers�o usada.
    options.ReportApiVersions = true; //Esta linha indica que as vers�es da API devem ser relatadas nas respostas. Isso � �til para os clientes saberem qual vers�o da API est�o usando e para depura��o.
});


builder.Services.AddControllers(); // Os controladores s�o respons�veis por lidar com as solicita��es HTTP e gerar respostas. Registrar esse servi�o � fundamental para o funcionamento de sua API.
builder.Services.AddEndpointsApiExplorer(); //Esse servi�o � usado em conjunto com o Swagger para explorar os pontos de extremidade da API e gerar a documenta��o. Ele � importante para gerar automaticamente a documenta��o do Swagger com base nos controladores e a��es definidos em sua API.
builder.Services.AddSwaggerGen(); //respons�vel por gerar a documenta��o do Swagger com base nas informa��es fornecidas em seus controladores e modelos de dados. Ele varre seu c�digo em busca de atributos e coment�rios XML para criar uma documenta��o detalhada da API.


////Conex�o 
string filePath = "C:\\Amauri\\GitHub\\BackendApiConnection1.txt";
string connectionString = File.ReadAllText(filePath).Replace("\\\\", "\\");
//string connectionStringjh = builder.Configuration.GetConnectionString("ConexaoPadrao");
Console.WriteLine(connectionString);
builder.Services.AddDbContext<MeuContext>(options => options.UseSqlServer(connectionString));

DependenciasDoEntity.Injetar(builder); //Declara as interfaces e repositorio
var config = new MapperConfiguration(cfg =>
{
    DependenciasDoMapper.Injetar(cfg);
}); //Declara os Request e responses
IMapper mapper = config.CreateMapper(); //usada para mapear objetos de um tipo para outro de maneira automatizada. O mapeamento � �til para converter objetos DTO
builder.Services.AddSingleton(mapper); //Esta linha est� registrando o objeto mapper como um servi�o Singleton no cont�iner de inje��o de depend�ncia da aplica��o. Isso significa que haver� uma �nica inst�ncia compartilhada desse objeto em toda a aplica��o. 
builder.Services.AddCors(); // usado para permitir que recursos da web em um dom�nio acessem recursos em outro dom�nio. Isso � �til quando voc� deseja que sua API seja acessada por clientes em diferentes dom�nios.
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //busca de classes de manipuladores de solicita��o. Essas classes s�o respons�veis por processar comandos e consultas em seu aplicativo.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ProcessarSolicitacaoRespostaHTTP>(); //� um middleware personalizado criado para lidar com erros e exce��es no aplicativo. Ele pode ser usado para centralizar o tratamento de erros em um �nico local, de modo que voc� n�o precise lidar com erros individualmente em todos os controladores ou camadas do aplicativo
 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
