using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Empleados.Application.Services;
using Empleados.Domain.Factories;
using System.Diagnostics.CodeAnalysis;

namespace Empleados.Application
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IEmpleadoFactory, EmpleadoFactory>();

            services.AddTransient<IHistoricoNavegacionService, HistoricoNavegacionService>();
            services.AddTransient<IHistoricoNavegacionFactory, HistoricoNavegacionFactory>();

            return services;
        }

    }
}
