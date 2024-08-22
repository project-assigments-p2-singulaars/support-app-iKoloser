using SupportAppV3.DTOs;

namespace SupportAppV3.Services;

public interface IUsuariosService
{
    Task<IEnumerable<UsuarioDto>> GetAllAsync();
    Task<UsuarioDto> GetByIdAsync(int id);
    Task AddAsync(UsuarioDto usuarioDto);
    Task UpdateAsync(UsuarioDto usuarioDto);
    Task DeleteAsync(int id);
}
