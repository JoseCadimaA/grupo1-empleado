﻿using Empleados.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.EF {
    public class UnitOfWork : IUnitOfWork {
        public Task Commit() {
            return Task.CompletedTask;
        }
    }
}
