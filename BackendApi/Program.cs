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
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


////Conexão 
string connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<MeuContext>(options => options.UseSqlServer(connectionString));

//Declara as interfaces e repositorio
DependenciasDoEntity.Injetar(builder);

//Declara os Request e responses
var config = new MapperConfiguration(cfg =>
{
    DependenciasDoMapper.Injetar(cfg);
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ErrorHandlerMiddleware>();
//app.UseMiddleware<BloquearAcessoMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
