using Employees.Shared.Entities;

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
            _context.Empleados.Add(new Empleado { FirstName = "Santiago", LastName = "Navarro", IsActive = true, HireDate = new DateTime(2019, 4, 3), Salary = 3800000 });
            _context.Empleados.Add(new Empleado { FirstName = "Valentina", LastName = "Rojas", IsActive = true, HireDate = new DateTime(2020, 9, 16), Salary = 4100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Julián", LastName = "Moreno", IsActive = true, HireDate = new DateTime(2021, 6, 22), Salary = 2900000 });
            _context.Empleados.Add(new Empleado { FirstName = "Paula", LastName = "Ortiz", IsActive = true, HireDate = new DateTime(2019, 2, 8), Salary = 4800000 });
            _context.Empleados.Add(new Empleado { FirstName = "Manuel", LastName = "Cárdenas", IsActive = true, HireDate = new DateTime(2023, 5, 11), Salary = 3050000 });
            _context.Empleados.Add(new Empleado { FirstName = "Daniela", LastName = "Jiménez", IsActive = true, HireDate = new DateTime(2021, 9, 27), Salary = 3600000 });
            _context.Empleados.Add(new Empleado { FirstName = "Sebastián", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2018, 7, 14), Salary = 5200000 });
            _context.Empleados.Add(new Empleado { FirstName = "Isabella", LastName = "Patiño", IsActive = true, HireDate = new DateTime(2020, 10, 19), Salary = 3100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Mateo", LastName = "Sánchez", IsActive = true, HireDate = new DateTime(2022, 11, 23), Salary = 3400000 });
            _context.Empleados.Add(new Empleado { FirstName = "Sara", LastName = "Velásquez", IsActive = true, HireDate = new DateTime(2021, 12, 2), Salary = 4300000 });
            _context.Empleados.Add(new Empleado { FirstName = "David", LastName = "Salazar", IsActive = true, HireDate = new DateTime(2019, 8, 7), Salary = 3700000 });
            _context.Empleados.Add(new Empleado { FirstName = "Tatiana", LastName = "Correa", IsActive = true, HireDate = new DateTime(2020, 3, 18), Salary = 4000000 });
            _context.Empleados.Add(new Empleado { FirstName = "Alejandro", LastName = "Cruz", IsActive = true, HireDate = new DateTime(2022, 1, 25), Salary = 3300000 });
            _context.Empleados.Add(new Empleado { FirstName = "Angélica", LastName = "Guzmán", IsActive = true, HireDate = new DateTime(2018, 6, 10), Salary = 5100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Mauricio", LastName = "Pineda", IsActive = true, HireDate = new DateTime(2021, 2, 17), Salary = 2950000 });
            _context.Empleados.Add(new Empleado { FirstName = "Eliana", LastName = "Carrillo", IsActive = true, HireDate = new DateTime(2023, 4, 9), Salary = 3500000 });
            _context.Empleados.Add(new Empleado { FirstName = "Cristian", LastName = "Muñoz", IsActive = true, HireDate = new DateTime(2019, 9, 21), Salary = 4600000 });
            _context.Empleados.Add(new Empleado { FirstName = "Carolina", LastName = "Fernández", IsActive = true, HireDate = new DateTime(2022, 7, 28), Salary = 3250000 });
            _context.Empleados.Add(new Empleado { FirstName = "Esteban", LastName = "Rincón", IsActive = true, HireDate = new DateTime(2020, 12, 5), Salary = 4100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Gabriela", LastName = "Nieto", IsActive = true, HireDate = new DateTime(2021, 10, 15), Salary = 3700000 });
            _context.Empleados.Add(new Empleado { FirstName = "Jorge", LastName = "Mejía", IsActive = true, HireDate = new DateTime(2018, 5, 13), Salary = 4900000 });
            _context.Empleados.Add(new Empleado { FirstName = "Lina", LastName = "Camacho", IsActive = true, HireDate = new DateTime(2020, 4, 1), Salary = 3100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Óscar", LastName = "Beltrán", IsActive = true, HireDate = new DateTime(2021, 6, 9), Salary = 4500000 });
            _context.Empleados.Add(new Empleado { FirstName = "Mónica", LastName = "Ramírez", IsActive = true, HireDate = new DateTime(2023, 8, 26), Salary = 2850000 });
            _context.Empleados.Add(new Empleado { FirstName = "Pedro", LastName = "Quiroga", IsActive = true, HireDate = new DateTime(2019, 1, 19), Salary = 5300000 });
            _context.Empleados.Add(new Empleado { FirstName = "Sandra", LastName = "Peña", IsActive = true, HireDate = new DateTime(2022, 5, 4), Salary = 3400000 });
            _context.Empleados.Add(new Empleado { FirstName = "Fernando", LastName = "Giraldo", IsActive = true, HireDate = new DateTime(2021, 3, 30), Salary = 3150000 });
            _context.Empleados.Add(new Empleado { FirstName = "Patricia", LastName = "Becerra", IsActive = true, HireDate = new DateTime(2020, 2, 6), Salary = 3900000 });
            _context.Empleados.Add(new Empleado { FirstName = "Héctor", LastName = "Trujillo", IsActive = true, HireDate = new DateTime(2019, 10, 9), Salary = 4450000 });
            _context.Empleados.Add(new Empleado { FirstName = "Verónica", LastName = "Pérez", IsActive = true, HireDate = new DateTime(2023, 3, 12), Salary = 3250000 });

            _context.Empleados.Add(new Empleado { FirstName = "Andrés", LastName = "Gaitán", IsActive = true, HireDate = new DateTime(2018, 11, 7), Salary = 5400000 });
            _context.Empleados.Add(new Empleado { FirstName = "Claudia", LastName = "Mora", IsActive = true, HireDate = new DateTime(2020, 6, 20), Salary = 3050000 });
            _context.Empleados.Add(new Empleado { FirstName = "Camilo", LastName = "Hernández", IsActive = true, HireDate = new DateTime(2022, 8, 1), Salary = 3650000 });
            _context.Empleados.Add(new Empleado { FirstName = "Liliana", LastName = "Suárez", IsActive = true, HireDate = new DateTime(2021, 1, 28), Salary = 4200000 });
            _context.Empleados.Add(new Empleado { FirstName = "Edgar", LastName = "Pardo", IsActive = true, HireDate = new DateTime(2023, 9, 5), Salary = 2800000 });
            _context.Empleados.Add(new Empleado { FirstName = "Rocío", LastName = "Valencia", IsActive = true, HireDate = new DateTime(2019, 3, 18), Salary = 3900000 });
            _context.Empleados.Add(new Empleado { FirstName = "Guillermo", LastName = "Arango", IsActive = true, HireDate = new DateTime(2020, 7, 29), Salary = 4400000 });
            _context.Empleados.Add(new Empleado { FirstName = "Marisol", LastName = "Peralta", IsActive = true, HireDate = new DateTime(2022, 12, 6), Salary = 3100000 });
            _context.Empleados.Add(new Empleado { FirstName = "Raúl", LastName = "Zapata", IsActive = true, HireDate = new DateTime(2021, 5, 25), Salary = 3550000 });
            _context.Empleados.Add(new Empleado { FirstName = "Nataly", LastName = "Rincón", IsActive = true, HireDate = new DateTime(2018, 9, 2), Salary = 5100000 });

            await _context.SaveChangesAsync();
        }
    }
}