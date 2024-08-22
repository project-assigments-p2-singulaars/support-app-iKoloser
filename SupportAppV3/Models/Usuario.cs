namespace SupportAppV3.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El nombre del usuario no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(256, ErrorMessage = "El correo electrónico no puede tener más de 256 caracteres.")]
    public string Email { get; set; }

    [Required]
    [StringLength(256, ErrorMessage = "El hash de la contraseña no puede tener más de 256 caracteres.")]
    public string PasswordHash { get; set; }

    public ICollection<UsuarioTarea> UsuarioTareas { get; set; } = new List<UsuarioTarea>();
}

