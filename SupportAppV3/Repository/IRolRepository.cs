using SupportAppV3.Models;

namespace SupportAppV3.Repository;

public interface IRolRepository
{
    Task<IEnumerable<Rol>> GetAllAsync();
    Task<Rol> GetByIdAsync(int id);
    Task AddAsync(Rol rol);
    Task UpdateAsync(Rol rol);
    Task DeleteAsync(int id);
}
