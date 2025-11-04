using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CountriesController : GenericController<Country>
    {
        private readonly ICountryUnitOfWork _countryUnitOfWork;

        public CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountryUnitOfWork countryUnitOfWork) : base(unitOfWork)
        {
            _countryUnitOfWork = countryUnitOfWork;
        }

        [HttpGet]

        public override async Task<IActionResult> GetAsync()
        {
            var action = await _countryUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]

        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _countryUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("{filtro}")]

        public override async Task<IActionResult> GetAsync(string filtro)
        {
            var action = await _countryUnitOfWork.GetAsync(filtro);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]

        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _countryUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]

        override public async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _countryUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}