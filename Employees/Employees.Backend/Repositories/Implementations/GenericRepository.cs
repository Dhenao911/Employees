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
            }
            catch
            {
                return new ActionResponse<T>
                {
                    Message = "No se puede borrar porque tiene registros relacionados"
                };
            }
        }

        //Metodo que filtra registros por nombres o apellidos si colocas "Ju" buscara registros que coincidan con esa cadena
        // Método genérico que busca registros que contengan una cadena de texto en cualquiera de sus campos de tipo string.
        // Método genérico que busca una cadena dentro de cualquier propiedad string de la entidad
        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(string filtro)
        {
            // Validamos que se haya enviado un texto para buscar
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = false,
                    Message = "Debe ingresar una cadena para buscar."
                };
            }

            // Convertimos el filtro a minúsculas para búsqueda sin distinción de mayúsculas
            filtro = filtro.ToLower();

            // Cargamos todos los registros de la entidad desde la base de datos
            var registros = await _entity.ToListAsync();

            // Obtenemos las propiedades tipo string de la clase genérica T
            var propiedadesTexto = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .ToList();

            // Filtramos en memoria (LINQ to Objects)
            var resultados = registros.Where(e =>
                propiedadesTexto.Any(p =>
                {
                    var valor = p.GetValue(e) as string;
                    return valor != null && valor.ToLower().Contains(filtro);
                })
            ).ToList();

            // Si hay resultados, los retornamos
            if (resultados.Any())
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = true,
                    Result = resultados
                };
            }

            // Si no se encuentra ningún registro, devolvemos un mensaje
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = false,
                Message = "No se encontraron registros que coincidan con la búsqueda."
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