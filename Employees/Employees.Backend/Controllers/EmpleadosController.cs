using Employees.Backend.Data;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpleadosController : GenericController<Empleado>
    {
        public EmpleadosController(IGenericUnitOfWork<Empleado> unitOfWork) : base(unitOfWork)
        {
        }
    }
}