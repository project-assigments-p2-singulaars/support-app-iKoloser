using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Services;

public class TareaService : ITareaService
{
    private readonly ITareaRepository _tareaRepository;

    public TareaService(ITareaRepository tareaRepository)
    {
        _tareaRepository = tareaRepository;
    }

    public async Task<IEnumerable<Tarea>> GetTareasForProyectoAsync(int proyectoId)
    {
        var tareas = await _tareaRepository.GetAllAsync();
        return tareas.Where(t => t.ProyectoId == proyectoId);
    }
}
