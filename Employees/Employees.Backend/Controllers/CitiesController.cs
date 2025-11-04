using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController: GenericController<City>
    {
        private readonly ICityUnitOfWork _cityUnitOfWork;

        public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICityUnitOfWork cityUnitOfWork) : base(unitOfWork)
        {
            _cityUnitOfWork = cityUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _cityUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _cityUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("{filtro}")]
        public override async Task<IActionResult> GetAsync(string filtro)
        {
            var action = await _cityUnitOfWork.GetAsync(filtro);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _cityUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _cityUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
