using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CadastroDePessoas.Service.Api.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                // Swagger v1 e v2
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio - Cadastro de pessoas v1",
                    Description = "Desafiio",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Desafio",
                        Email = "desafio@teste.com.br",
                        Url = new Uri("http://www.desafio.com.br")
                    }
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Desafio - Cadastro de pessoas v2",
                    Description = "Desafiio",
                    Version = "v2",
                    Contact = new OpenApiContact
                    {
                        Name = "Desafio",
                        Email = "desafio@teste.com.br",
                        Url = new Uri("http://www.desafio.com.br")
                    }
                });

                // 📌 Suporte ao Bearer Token
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta forma: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "bearer",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });

                // Comentários XML (opcional)
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroDePessoasApi v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "CadastroDePessoasApi v2");
            });

            return app;
        }
    }
}

