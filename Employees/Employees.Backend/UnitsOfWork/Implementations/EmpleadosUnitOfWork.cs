using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.UnitsOfWork.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Employees.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class EmpleadosUnitOfWork : GenericUnitOfWork<Empleado>, IEmpleadosUnitOfWork
    {
        
        private readonly IEmpleadosRepository _empleadosRepository;

        public EmpleadosUnitOfWork(IGenericRepository<Empleado> repository, IEmpleadosRepository empleadosRepository) : base(repository)
        {
           
            _empleadosRepository = empleadosRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync() => await  _empleadosRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro) => await _empleadosRepository.GetAsync(filtro);
       
        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(PaginationDTO pagination) => await _empleadosRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _empleadosRepository.GetTotalRecordsAsync(pagination);


    }



}
