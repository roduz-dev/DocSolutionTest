using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IEmpleado : IDisposable
    {
        IEnumerable<Empleado> GetEmpleadoByNombre(string nombre);
        int CreateEmpleado(Empleado persona); 

    }
}
