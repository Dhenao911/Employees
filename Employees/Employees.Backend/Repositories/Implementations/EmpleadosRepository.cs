using Employees.Backend.Data;
using Employees.Backend.Helpers;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repositories.Implementations
{
    public class EmpleadosRepository : GenericRepository<Empleado>, IEmpleadosRepository
    {
        private readonly DataContext _context;

        public EmpleadosRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = empleados
            };
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro)
        {
            filtro = filtro.ToLower();
            var empleados = await _context.Empleados
                .Where(e => e.FirstName.ToLower().Contains(filtro) || e.LastName.ToLower().Contains(filtro))
                .ToListAsync();

            if (empleados == null)
            {
                return new ActionResponse<IEnumerable<Empleado>>
                {
                    Message = "No se encontraron empleados que coincidan con esos caracteres"
                };
            }

            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = empleados
            };
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync( PaginationDTO pagination)
        {
            var queryable = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.FirstName.ToLower().Contains(pagination.Filter) || 
                e.LastName.ToLower().Contains(pagination.Filter));
            }

            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.FirstName.ToLower().Contains(pagination.Filter.ToLower()) 
                || e.LastName.ToLower().Contains(pagination.Filter.ToLower()));
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