using Microsoft.Extensions.DependencyInjection;

namespace CadastroDePessoas.Infraestructure.IoC.Extensions
{
    public static class AutoMaperExtension
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
