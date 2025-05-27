using CadastroDePessoas.Application.Interfaces.Auth;
using CadastroDePessoas.Application.Interfaces.Pessoas;
using CadastroDePessoas.Application.Interfaces.Usuarios;
using CadastroDePessoas.Application.Services.Auth;
using CadastroDePessoas.Application.Services.Pessoas;
using CadastroDePessoas.Application.Services.Usuarios;
using CadastroDePessoas.Domain.Interfaces.Repositories;
using CadastroDePessoas.Domain.Interfaces.Services.Auth;
using CadastroDePessoas.Domain.Interfaces.Services.Pessoas;
using CadastroDePessoas.Domain.Interfaces.Services.Usuarios;
using CadastroDePessoas.Domain.Services.Auth;
using CadastroDePessoas.Domain.Services.Pessoas;
using CadastroDePessoas.Domain.Services.Usuarios;
using CadastroDePessoas.Infraestructure.Data.Contexts;
using CadastroDePessoas.Infraestructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDePessoas.Infraestructure.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPessoaDomainService, PessoaDomainService>();
            services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();
            services.AddScoped<IAuthDomainService, AuthDomainService>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataSeeder>();

            return services;
        }
    }
}
