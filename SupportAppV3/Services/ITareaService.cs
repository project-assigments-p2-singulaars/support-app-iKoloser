using SupportAppV3.Models;

namespace SupportAppV3.Services;

public interface ITareaService
{
    Task<IEnumerable<Tarea>> GetTareasForProyectoAsync(int proyectoId);
}
