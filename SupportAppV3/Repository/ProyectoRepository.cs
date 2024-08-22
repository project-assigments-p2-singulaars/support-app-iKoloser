using Microsoft.EntityFrameworkCore;
using SupportAppV3.Data;
using SupportAppV3.Models;

namespace SupportAppV3.Repository;

public class ProyectoRepository : IProyectoRepository
{
    private readonly ApplicationDbContext _context;

    public ProyectoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Proyecto>> GetAllAsync()
    {
        return await _context.Proyectos.Include(p => p.Tareas).ToListAsync();
    }

    public async Task<Proyecto> GetByIdAsync(int id)
    {
        return await _context.Proyectos.Include(p => p.Tareas)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Proyecto proyecto)
    {
        await _context.Proyectos.AddAsync(proyecto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Proyecto proyecto)
    {
        _context.Proyectos.Update(proyecto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto != null)
        {
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
        }
    }
}
