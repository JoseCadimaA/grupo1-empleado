using Empleados.Domain.Repositories;
using Empleados.Infraestructure.EF;
using Empleados.Infraestructure.MemoryRepository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Empleados.Infraestructure {
    [ExcludeFromCodeCoverage]
    public static class Extensions {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            //TODO: Eliminar despues. Solo para proposito de pruebas
            services.AddSingleton<MemoryDatabase>();

            services.AddScoped<IEmpleadoRepository, MemoryEmpleadoRepository>();
            services.AddScoped<IHistoricoNavegacionRepository, MemoryHistoricoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
