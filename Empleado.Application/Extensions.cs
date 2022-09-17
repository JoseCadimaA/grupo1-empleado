using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Empleados.Application.Services;
using Empleados.Domain.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Empleados.Application {
    [ExcludeFromCodeCoverage]
    public static class Extensions {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IEmpleadoFactory, EmpleadoFactory>();

            services.AddTransient<IHistoricoNavegacionService, HistoricoNavegacionService>();
            services.AddTransient<IHistoricoNavegacionFactory, HistoricoNavegacionFactory>();

            return services;
        }

    }
}
