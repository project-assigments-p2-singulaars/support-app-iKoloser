using SupportAppV3.DTOs;

namespace SupportAppV3.Services;

public interface IUsuarioTareaService
{
    Task<IEnumerable<UsuarioTareaDto>> GetAllAsync();
    Task<UsuarioTareaDto> GetByIdAsync(int usuarioId, int tareaId, int rolId);
    Task AddAsync(UsuarioTareaDto usuarioTareaDto);
    Task UpdateAsync(UsuarioTareaDto usuarioTareaDto);
    Task DeleteAsync(int usuarioId, int tareaId, int rolId);
}