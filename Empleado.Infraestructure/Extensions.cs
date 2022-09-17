using System.Diagnostics.CodeAnalysis;
using Empleados.Domain.Repositories;
using Empleados.Infraestructure.EF;
using Empleados.Infraestructure.MemoryRepository;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empleados.Infraestructure {
    [ExcludeFromCodeCoverage]
    public static class Extensions {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            //TODO: Eliminar despues. Solo para proposito de pruebas
            services.AddSingleton<MemoryDatabase>();

            services.AddScoped<IEmpleadoRepository, MemoryEmpleadoRepository>();
            services.AddScoped<IHistoricoNavegacionRepository, MemoryHistoricoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            AddRabbitMq(services, configuration);

            return services;
        }

        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config => {
                config.UsingRabbitMq((context, cfg) => {
                    var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);
                });
            });
        }

    }
}
