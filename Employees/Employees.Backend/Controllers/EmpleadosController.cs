using Employees.Backend.Data;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Empleados.ToListAsync());
        }

        /*[HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id==id);

            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }*/

        [HttpGet("{nombre}")]

        public async Task<IActionResult> Get(string nombre)
        {
            var empleado = await _context.Empleados.Where(e=>e.FirstName.Contains(nombre)).ToListAsync();

            if(empleado==null || empleado.Count==0)
                return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Empleado empleado)
        {
            _context.Update(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }

        [HttpDelete ("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if(empleado==null)
                return NotFound();

            _context.Remove(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }
    }
}