using Employees.Frontend.Repositories;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Components;


namespace Employees.Frontend.Components.Pages.Empleados
{
    public partial class EmployeesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        private List<Empleado>? Empleados;

        protected override async Task OnInitializedAsync()
        {
            var httpResult= await Repository.GetAsync<List<Empleado>>("api/Empleados");
            Empleados = httpResult.Response;
        }

    }
}