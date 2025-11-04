using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class CountryUnitOfWork : GenericUnitOfWork<Country>, ICountryUnitOfWork
    {
        private readonly ICountryRepository _countryRepository;

        public CountryUnitOfWork(IGenericRepository<Country> repository, ICountryRepository countryRepository) : base(repository)
        {
            _countryRepository = countryRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countryRepository.GetAsync();

        public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countryRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(string filtro) => await _countryRepository.GetAsync(filtro);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) => await _countryRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _countryRepository.GetTotalRecordsAsync(pagination);
    }
}