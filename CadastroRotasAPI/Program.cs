using CadastroRotasAPI;
using CadastroRotasRepository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Sistema de Rotas",
        Description = "Esta API é responsável pela gestão e busca otimizada de rotas de viagem, permitindo identificar os melhores caminhos entre origens e destinos especificados. Funcionalidades incluem cálculo do caminho mais curto e do mais econômico, baseando-se em dados de distância e custo.",
        Contact = new OpenApiContact
        {
            Name = "Suporte Sistema de Rotas",
            Url = new Uri("https://example.com/contact")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});
DependencyInjection.Register(builder.Services);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();
app.UseRouting();

app.Run();
