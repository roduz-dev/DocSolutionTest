using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations
{
    public class EmpleadoRepository : IEmpleado
    {
        private readonly ApplicationDbContext _context;
        public EmpleadoRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public int CreateEmpleado(Empleado empleado)
        {
            int result = -1;
            if(empleado == null)
            {
                result = 0;
            }
            else
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                result = empleado.Id;
            }
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Empleado> GetEmpleadoByNombre(string nombre)
        {
            IEnumerable<Empleado> empleados = _context.Empleados.Where(p => p.Nombre == nombre);
            return empleados;
        }
    }
}
