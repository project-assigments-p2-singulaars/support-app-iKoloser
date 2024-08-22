namespace SupportAppV3.DTOs;

public class TareaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool EstaRealizada { get; set; }
    public int ProyectoId { get; set; }
}
