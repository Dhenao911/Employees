using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync();

        Task<ActionResponse<City>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<City>>> GetAsync(string filtro);

        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}
