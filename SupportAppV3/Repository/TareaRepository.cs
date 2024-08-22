using Microsoft.EntityFrameworkCore;
using SupportAppV3.Data;
using SupportAppV3.Models;

namespace SupportAppV3.Repository;

public class TareaRepository : ITareaRepository
{
    private readonly ApplicationDbContext _context;

    public TareaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarea>> GetAllAsync()
    {
        return await _context.Tareas.Include(t => t.ProyectoId).ToListAsync();
    }

    public async Task<Tarea> GetByIdAsync(int id)
    {
        return await _context.Tareas.Include(t => t.Proyecto)
            .Include(t => t.UsuarioTareas)
            .ThenInclude(ut => ut.Usuario)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Tarea tarea)
    {
        await _context.Tareas.AddAsync(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tarea tarea)
    {
        _context.Tareas.Update(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea != null)
        {
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
        }
    }
}
