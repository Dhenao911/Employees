using Employees.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Employees.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<State> States { get; set; }

        // Para crear index y evitar repeticiones de nombres de los tipos de categorias
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(s => new { s.CountryId, s.Name })
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c=>new { c.StateId, c.Name })
                .IsUnique();

            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}