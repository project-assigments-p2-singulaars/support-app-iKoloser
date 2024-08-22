using SupportAppV3.DTOs;

namespace SupportAppV3.Services;

public interface IRolService
{
    Task<IEnumerable<RolDto>> GetAllAsync();
    Task<RolDto> GetByIdAsync(int id);
    Task AddAsync(RolDto rolDto);
    Task UpdateAsync(RolDto rolDto);
    Task DeleteAsync(int id);
}