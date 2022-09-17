using System.Threading.Tasks;

namespace Empleados.Domain.Repositories {
    public interface IUnitOfWork {
        Task Commit();
    }
}
