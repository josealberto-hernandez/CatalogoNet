using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products;
using Catalogo.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Catalogo.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            services.AddDbContext<CatalogoDbContext>(opt => {
                
                opt.LogTo(Console.WriteLine, new[] {
                    DbLoggerCategory.Database.Command.Name
                }, LogLevel.Information).EnableSensitiveDataLogging();

                opt.UseSqlite(
                    configuration.GetConnectionString("SqliteProduct")
                ).UseSnakeCaseNamingConvention();

            });

            services
            .AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CatalogoDbContext>());
            
            services.AddScoped<IProductRepository, ProductRepository>();

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);


            return services;
        }

}