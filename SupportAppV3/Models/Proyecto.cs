namespace SupportAppV3.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Proyecto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El nombre del proyecto no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; }

    [Required]
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

