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

namespace Empleados.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IEmpleadoFactory, EmpleadoFactory>();



            return services;
        }

    }
}
