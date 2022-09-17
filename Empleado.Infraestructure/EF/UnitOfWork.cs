using System.Threading.Tasks;
using Empleados.Domain.Repositories;

namespace Empleados.Infraestructure.EF {
    public class UnitOfWork : IUnitOfWork {

        //private readonly WriteDbContext _context;

        public Task Commit() {


            return Task.CompletedTask;
        }
    }
}
