using SupportAppV3.DTOs;
using SupportAppV3.Models;

namespace SupportAppV3.Services;

public interface IProyectosService
{
    Task<IEnumerable<ProyectoDto>> GetAllAsync();
    Task<ProyectoDto> GetByIdAsync(int id);
    Task AddAsync(ProyectoDto proyectoDto);
    Task UpdateAsync(ProyectoDto proyectoDto);
    Task DeleteAsync(int id);
}