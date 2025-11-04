using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces
{
    public interface IStateRepository
    {
        Task<ActionResponse<IEnumerable<State>>> GetAsync();

        Task<ActionResponse<State>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<State>>> GetAsync(string filtro);

        Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}
