using Catalogo.Api.Extensions;
using Catalogo.Application;
using Catalogo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catalogo de Productos",
        Version = "v1"
    });
 });


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplycation();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.ApplyMigration();

app.MapControllers();

app.Run();