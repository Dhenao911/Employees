using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Interfaces
{
    public interface IEmpleadosUnitOfWork
    {
        Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(); 
        Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro);
    }
}
