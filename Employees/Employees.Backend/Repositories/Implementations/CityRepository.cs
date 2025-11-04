using Employees.Backend.Data;
using Employees.Backend.Helpers;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repositories.Implementations
{
    public class CityRepository: GenericRepository<City>, ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync()
        {
            var city = await _context.Cities
                .AsNoTracking()
                .ToListAsync();
            return new ActionResponse<IEnumerable<City>>
            {
                WasSuccess = true,
                Result = city
            };
        }

        public override async Task<ActionResponse<City>> GetAsync(int id)
        {
            var city = await _context.Cities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return new ActionResponse<City>
            {
                WasSuccess = true,
                Result = city
            };
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(string filtro)
        {
            var city = await _context.Cities
                .AsNoTracking()
                .Where(c => c.Name.Contains(filtro))
                .ToListAsync();
            if (city == null)
            {
                return new ActionResponse<IEnumerable<City>>
                {
                    Message = "No se encontraron estados que coincidan con esos caracteres"
                };
            }
            return new ActionResponse<IEnumerable<City>>
            {
                WasSuccess = true,
                Result = city
            };
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<City>>
            {
                WasSuccess = true,
                Result = await queryable
                .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}
