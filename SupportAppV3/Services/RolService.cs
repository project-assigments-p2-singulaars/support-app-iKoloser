using AutoMapper;
using SupportAppV3.DTOs;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Services;

public class RolesService : IRolService
{
    private readonly IRolRepository _rolRepository;
    private readonly IMapper _mapper;

    public RolesService(IRolRepository rolRepository, IMapper mapper)
    {
        _rolRepository = rolRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RolDto>> GetAllAsync()
    {
        var roles = await _rolRepository.GetAllAsync();
        return roles.Select(r => _mapper.Map<RolDto>(r));
    }

    public async Task<RolDto> GetByIdAsync(int id)
    {
        var rol = await _rolRepository.GetByIdAsync(id);
        return _mapper.Map<RolDto>(rol);
    }

    public async Task AddAsync(RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        await _rolRepository.AddAsync(rol);
    }

    public async Task UpdateAsync(RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        await _rolRepository.UpdateAsync(rol);
    }

    public async Task DeleteAsync(int id)
    {
        await _rolRepository.DeleteAsync(id);
    }
}
