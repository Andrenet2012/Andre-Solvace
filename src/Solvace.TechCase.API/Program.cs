using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Repository.Interface;
using Solvace.TechCase.Services;
using Solvace.TechCase.API.Configuracao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DefaultContext>(
    x => x.UseSqlite(builder.Configuration.GetConnectionString("defaultConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IActionPlanService, ActionPlanService>();
builder.Services.AddScoped<IProductServices, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Erro>();

app.UseHttpsRedirection();

app.MapControllers();




app.Run();

