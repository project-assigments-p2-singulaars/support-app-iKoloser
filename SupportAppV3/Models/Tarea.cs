namespace SupportAppV3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Tarea
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El nombre de la tarea no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; }

    [Required]
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    [Required]
    public bool EstaRealizada { get; set; }

    [Required]
    public int ProyectoId { get; set; }

    public Proyecto Proyecto { get; set; }

    public ICollection<UsuarioTarea> UsuarioTareas { get; set; } = new List<UsuarioTarea>();
}

