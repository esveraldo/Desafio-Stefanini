using CadastroDePessoas.Infraestructure.IoC.Extensions;
using CadastroDePessoas.Service.Api.Extensions;
using CadastroDePessoas.Service.Api.Middlewares;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
builder.Services.AddDbContextConfig(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Isso é crucial!
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

app.UseDatabaseSeeder();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseSwaggerDoc();
app.UseAuthentication();
app.UseAuthorization();
app.UseCorsPolicy();

app.MapControllers();

app.Run();

public partial class Program { }
