using CadastroDePessoas.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDePessoas.Infraestructure.IoC.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig
            (this IServiceCollection services, IConfiguration configuration)
        {

            var databaseProvider = configuration.GetSection("DatabaseProvider").Value;

            switch (databaseProvider)
            {
                case "SqlServer":
                    services.AddDbContext<DataContext>(options => {
                        options.UseSqlServer(configuration.GetConnectionString("cadastroDePessoas"));
                    });
                    break;

                case "InMemory":
                    services.AddDbContext<DataContext>(options => {
                        options.UseInMemoryDatabase(databaseName: "cadastroDePessoas");
                    });
                    break;
            }

            return services;
        }
    }
}
