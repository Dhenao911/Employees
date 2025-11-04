using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class CityUnitOfWork: GenericUnitOfWork<City>, ICityUnitOfWork
    {
        private readonly ICityRepository _cityRepository;

        public CityUnitOfWork(IGenericRepository<City> repository, ICityRepository cityRepository) : base(repository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync() => await _cityRepository.GetAsync();

        public override async Task<ActionResponse<City>> GetAsync(int id) => await _cityRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(string filtro) => await _cityRepository.GetAsync(filtro);

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _cityRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _cityRepository.GetTotalRecordsAsync(pagination);
    }
}
