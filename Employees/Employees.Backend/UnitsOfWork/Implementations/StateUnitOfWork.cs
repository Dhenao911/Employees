using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class StateUnitOfWork : GenericUnitOfWork<State>, IStateUnitOfWork
    {
        private readonly IStateRepository _stateRepository;

        public StateUnitOfWork(IGenericRepository<State> repository, IStateRepository stateRepository) : base(repository)
        {
            _stateRepository = stateRepository;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _stateRepository.GetAsync();

        public override async Task<ActionResponse<State>> GetAsync(int id) => await _stateRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(string filtro) => await _stateRepository.GetAsync(filtro);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _stateRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _stateRepository.GetTotalRecordsAsync(pagination);
    }
}