namespace SupportAppV3.Repository;
using Microsoft.EntityFrameworkCore;
using SupportAppV3.Repository;
using Microsoft.EntityFrameworkCore;
using SupportAppV3.Data;
using SupportAppV3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class UsuarioTareaRepository : IUsuarioTareaRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioTareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioTarea>> GetAllAsync()
        {
            return await _context.UsuarioTareas.ToListAsync();
        }

        public async Task<UsuarioTarea> GetByIdAsync(int usuarioId, int tareaId, int rolId)
        {
            return await _context.UsuarioTareas
                .FirstOrDefaultAsync(ut => ut.UsuarioId == usuarioId && ut.TareaId == tareaId && ut.RolId == rolId);
        }

        public async Task AddAsync(UsuarioTarea usuarioTarea)
        {
            await _context.UsuarioTareas.AddAsync(usuarioTarea);
            await _context.SaveChangesAsync();
        }

        public void Update(UsuarioTarea usuarioTarea)
        {
            _context.UsuarioTareas.Update(usuarioTarea);
            _context.SaveChanges();
        }

        public void Delete(UsuarioTarea usuarioTarea)
        {
            _context.UsuarioTareas.Remove(usuarioTarea);
            _context.SaveChanges();
        }
}
