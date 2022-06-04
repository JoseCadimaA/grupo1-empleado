﻿using Empleados.Domain.Repositories;
using Empleados.Infraestructure.MemoryRepository;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.MemoryRepository
{
    public class MemoryEmpleadoRepository : IEmpleadoRepository
    {
        private readonly MemoryDatabase _database;

        public MemoryEmpleadoRepository(MemoryDatabase database)
        {
            _database = database;
        }

        public Task<Domain.Model.Empleado.Empleado> FindByIdAsync(Guid id)
        {
            return Task.FromResult(_database.Empleados.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync(Domain.Model.Empleado.Empleado obj)
        {
            return Task.CompletedTask;
        }

        public Task RegistrarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            _database.Empleados.Add(obj);
            return Task.CompletedTask;
        }

        public Task ActualizarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Task EliminarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerEmpleadoByTipo(string tipo)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerListaEmpleados()
        {
            throw new NotImplementedException();
        }

        Task<Domain.Model.Empleado.Empleado> IRepository<Domain.Model.Empleado.Empleado, Guid>.FindByIdAsync(Guid id)
        {
            return Task.FromResult(_database.Empleados.FirstOrDefault(x => x.Id == id));
        }

        public Task CreateAsync(Domain.Model.Empleado.Empleado obj)
        {
            _database.Empleados.Add(obj);
            return Task.CompletedTask;
        }

        public Task<Domain.Model.Empleado.Empleado> FindByFKAsync(Guid idFk)
        {
            throw new NotImplementedException();
        }
    }
}