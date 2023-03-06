using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace SistemaCompra.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema Compra",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "Eridani L. Campos", Email ="eridanicampos@hotmail.com"}
                });
            });
        }
    }
}
