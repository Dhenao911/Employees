using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces
{
    public interface IEmpleadosRepository
    {
        Task<ActionResponse<IEnumerable<Empleado>>> GetAsync();
        Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro);

       
    }
}