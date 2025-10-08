
using Employees.Shared.Entities;
using System.Data;

namespace Employees.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await checkEmpleadosAsync();
    }

    private async Task checkEmpleadosAsync()
    {
        if (!_context.Empleados.Any())
        {
            _context.Empleados.Add(new Empleado { FirstName = "Juan", LastName = "Pérez", IsActive = true, HireDate = new DateTime(2021, 5, 10), Salary = 3500000 });
            _context.Empleados.Add(new Empleado { FirstName = "María", LastName = "Gómez", IsActive = true, HireDate = new DateTime(2020, 8, 22), Salary = 4200000 });
            _context.Empleados.Add(new Empleado { FirstName = "Carlos", LastName = "Rodríguez", IsActive = true, HireDate = new DateTime(2022, 2, 14), Salary = 3100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Laura", LastName = "Martínez", IsActive = true, HireDate = new DateTime(2019, 11, 30), Salary = 5000000 });
            _context.Empleados.Add(new Empleado { FirstName = "Andrés", LastName = "López", IsActive = true, HireDate = new DateTime(2023, 3, 5), Salary = 2800000 });
            _context.Empleados.Add(new Empleado { FirstName = "Diana", LastName = "Ruiz", IsActive = true, HireDate = new DateTime(2021, 7, 19), Salary = 3300000 });
            _context.Empleados.Add(new Empleado { FirstName = "Felipe", LastName = "Castro", IsActive = true, HireDate = new DateTime(2020, 1, 25), Salary = 4700000 });
            _context.Empleados.Add(new Empleado { FirstName = "Natalia", LastName = "Torres", IsActive = true, HireDate = new DateTime(2022, 9, 8), Salary = 2950000 });
            _context.Empleados.Add(new Empleado { FirstName = "Ricardo", LastName = "García", IsActive = true, HireDate = new DateTime(2018, 12, 12), Salary = 5500000 });
            _context.Empleados.Add(new Empleado { FirstName = "Camila", LastName = "Mendoza", IsActive = true, HireDate = new DateTime(2023, 1, 10), Salary = 3200000 });

            await _context.SaveChangesAsync();


        }
    }
}
