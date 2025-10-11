using Employees.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;

namespace Employees.Frontend.Components.Pages.Empleados;

public partial class EmployeesForm
{
    private EditContext editContext = null!;

    [EditorRequired, Parameter] public Empleado Empleado { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    protected override void OnInitialized()
    {    
        editContext = new(Empleado);

       
    }
}

