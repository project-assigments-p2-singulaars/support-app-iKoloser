namespace SupportAppV3.DTOs;

public class UsuarioTareaDto
{
    public int UsuarioId { get; set; }
    public int TareaId { get; set; }
    public int RolId { get; set; }
    public UsuarioDto Usuario { get; set; }
    public TareaDto Tarea { get; set; }
    public RolDto Rol { get; set; }
}