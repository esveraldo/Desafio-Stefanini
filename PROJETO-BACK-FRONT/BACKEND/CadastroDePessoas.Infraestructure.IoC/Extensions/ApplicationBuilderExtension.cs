using CadastroDePessoas.Infraestructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDePessoas.Infraestructure.IoC.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseDatabaseSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            seeder.Seed();
        }
    }
}
