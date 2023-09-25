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
    options.AssumeDefaultVersionWhenUnspecified = true; // Essa linha indica que, se a versão da API não for especificada na solicitação, a versão padrão será assumida. Isso significa que se o cliente não informar a versão da API, a versão padrão (1.0 neste caso) será usada automaticamente.
    options.DefaultApiVersion = new ApiVersion(1, 0); //Define a versão padrão da API. Como mencionado anteriormente, se a versão não for especificada na solicitação, esta será a versão usada.
    options.ReportApiVersions = true; //Esta linha indica que as versões da API devem ser relatadas nas respostas. Isso é útil para os clientes saberem qual versão da API estão usando e para depuração.
});


builder.Services.AddControllers(); // Os controladores são responsáveis por lidar com as solicitações HTTP e gerar respostas. Registrar esse serviço é fundamental para o funcionamento de sua API.
builder.Services.AddEndpointsApiExplorer(); //Esse serviço é usado em conjunto com o Swagger para explorar os pontos de extremidade da API e gerar a documentação. Ele é importante para gerar automaticamente a documentação do Swagger com base nos controladores e ações definidos em sua API.
builder.Services.AddSwaggerGen(); //responsável por gerar a documentação do Swagger com base nas informações fornecidas em seus controladores e modelos de dados. Ele varre seu código em busca de atributos e comentários XML para criar uma documentação detalhada da API.


////Conexão 
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
IMapper mapper = config.CreateMapper(); //usada para mapear objetos de um tipo para outro de maneira automatizada. O mapeamento é útil para converter objetos DTO
builder.Services.AddSingleton(mapper); //Esta linha está registrando o objeto mapper como um serviço Singleton no contêiner de injeção de dependência da aplicação. Isso significa que haverá uma única instância compartilhada desse objeto em toda a aplicação. 
builder.Services.AddCors(); // usado para permitir que recursos da web em um domínio acessem recursos em outro domínio. Isso é útil quando você deseja que sua API seja acessada por clientes em diferentes domínios.
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //busca de classes de manipuladores de solicitação. Essas classes são responsáveis por processar comandos e consultas em seu aplicativo.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ProcessarSolicitacaoRespostaHTTP>(); //é um middleware personalizado criado para lidar com erros e exceções no aplicativo. Ele pode ser usado para centralizar o tratamento de erros em um único local, de modo que você não precise lidar com erros individualmente em todos os controladores ou camadas do aplicativo
 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
