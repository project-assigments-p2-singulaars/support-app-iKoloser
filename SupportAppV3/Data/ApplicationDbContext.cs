using Microsoft.EntityFrameworkCore;
using SupportAppV3.Models;

namespace SupportAppV3.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Proyecto> Proyectos { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UsuarioTarea> UsuarioTareas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UsuarioTarea>()
            .HasKey(ut => new { ut.UsuarioId, ut.TareaId, ut.RolId });

        modelBuilder.Entity<UsuarioTarea>()
            .HasOne(ut => ut.Usuario)
            .WithMany(u => u.UsuarioTareas)
            .HasForeignKey(ut => ut.UsuarioId);

        modelBuilder.Entity<UsuarioTarea>()
            .HasOne(ut => ut.Tarea)
            .WithMany(t => t.UsuarioTareas)
            .HasForeignKey(ut => ut.TareaId);

        modelBuilder.Entity<UsuarioTarea>()
            .HasOne(ut => ut.Rol)
            .WithMany(r => r.UsuarioTareas)
            .HasForeignKey(ut => ut.RolId);
    }
}
