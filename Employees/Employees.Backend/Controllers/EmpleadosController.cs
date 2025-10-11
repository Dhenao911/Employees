using Employees.Backend.Data;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpleadosController : GenericController<Empleado>
    {
        private readonly IEmpleadosUnitOfWork _empleadosUnitOfWork;

        public EmpleadosController(IGenericUnitOfWork<Empleado> unitOfWork,IEmpleadosUnitOfWork empleadosUnitOfWork) : base(unitOfWork)
        {
            _empleadosUnitOfWork = empleadosUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _empleadosUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        //Este metodo me filtra por nombre o apellido
        [HttpGet("{filtro}")]
        public override async Task<IActionResult> GetAsync(string filtro)
        {
            var action = await _empleadosUnitOfWork.GetAsync(filtro);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _empleadosUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        override public async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _empleadosUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}