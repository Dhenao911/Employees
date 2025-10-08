using Employees.Backend.Data;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employees.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception Exception)
            {
                return ExceptionActionResponse(Exception);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
           
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }

            _entity.Remove(row);

            try
            {
                await _context.SaveChangesAsync();

                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }catch 
            {
                return new ActionResponse<T>
                {
                    Message = "No se puede borrar porque tiene registros relacionados"
                };
            }
        }


        //Metodo que filtra registros por nombres o apellidos si colocas "Ju" buscara registros que coincidan con esa cadena
        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(string busqueda)
        {
            
            //Busca en la base de datos que existan campos o propiedades que coincidan con FirstName o LastName
            var propiedadFirstName = typeof(T).GetProperty("FirstName");
            var propiedadLastName = typeof(T).GetProperty("LastName");

            //Verifica que existan esas propiedades
            if (propiedadFirstName == null && propiedadLastName == null)
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = false,
                    Message = $"La entidad {typeof(T).Name} no tiene propiedades FirstName o LastName para búsqueda."
                };
            }

            //Filtra el registro que coincida con la cadena de caracteres

            var query = _entity.AsQueryable();

            //Filtra por FirtName y LastName
            if (propiedadFirstName != null && propiedadLastName != null)
            {
                query = query.Where(e =>
                    EF.Functions.Like(EF.Property<string>(e, propiedadFirstName.Name), $"%{busqueda}%") ||
                    EF.Functions.Like(EF.Property<string>(e, propiedadLastName.Name), $"%{busqueda}%"));
            }
            //filtra solo por FirstName si este coincide
            else if (propiedadFirstName != null)
            {
                query = query.Where(e =>
                    EF.Functions.Like(EF.Property<string>(e, propiedadFirstName.Name), $"%{busqueda}%"));
            }
            //Si no solo filtra por LastName
            else
            {
                query = query.Where(e =>
                    EF.Functions.Like(EF.Property<string>(e, propiedadLastName.Name), $"%{busqueda}%"));
            }
  

            var resultados = await query.ToListAsync();

            //Si no hay resultado no devuelve nada
            if (resultados == null || resultados.Count == 0)
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = false,
                    Message = $"No se encontraron registros de {typeof(T).Name} que contengan '{busqueda}'."
                };
            }

            //Devuelve la lista con los resultados que coincidan
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = resultados
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
        };

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception Exception)
            {
                return ExceptionActionResponse(Exception);
            }
        }

        private ActionResponse<T> ExceptionActionResponse(Exception exception) => new ActionResponse<T>
        {
            Message = exception.Message
        };

        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
        {
            Message = " Ya existe el registro. "
        };
    }
}