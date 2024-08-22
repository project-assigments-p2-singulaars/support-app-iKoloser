namespace SupportAppV3.Models;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

public class UsuarioTarea
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int TareaId { get; set; }
    public Tarea Tarea { get; set; }

    public int RolId { get; set; }
    public Rol Rol { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "El rol no puede tener más de 50 caracteres.")]
    public string RolNombre { get; set; }
}


