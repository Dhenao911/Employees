using Employees.Backend.Data;
using Employees.Backend.Repositories.Interfaces;
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

        public async override Task<ActionResponse<IEnumerable<Empleado>>> GetAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = empleados
            };

        }

        public async override Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro)
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
       
    }
}
