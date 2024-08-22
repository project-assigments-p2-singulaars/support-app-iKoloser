namespace SupportAppV3.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Rol
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "El nombre del rol no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    public ICollection<UsuarioTarea> UsuarioTareas { get; set; } = new List<UsuarioTarea>();
}

