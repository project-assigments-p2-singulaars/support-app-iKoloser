using AutoMapper;
using SupportAppV3.DTOs;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Services;

public class ProyectosService : IProyectosService
{
    private readonly IProyectoRepository _proyectoRepository;
    private readonly IMapper _mapper;

    public ProyectosService(IProyectoRepository proyectoRepository, IMapper mapper)
    {
        _proyectoRepository = proyectoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProyectoDto>> GetAllAsync()
    {
        var proyectos = await _proyectoRepository.GetAllAsync();
        return proyectos.Select(p => _mapper.Map<ProyectoDto>(p));
    }

    public async Task<ProyectoDto> GetByIdAsync(int id)
    {
        var proyecto = await _proyectoRepository.GetByIdAsync(id);
        return _mapper.Map<ProyectoDto>(proyecto);
    }

    public async Task AddAsync(ProyectoDto proyectoDto)
    {
        var proyecto = _mapper.Map<Proyecto>(proyectoDto);
        await _proyectoRepository.AddAsync(proyecto);
    }

    public async Task UpdateAsync(ProyectoDto proyectoDto)
    {
        var proyecto = _mapper.Map<Proyecto>(proyectoDto);
        await _proyectoRepository.UpdateAsync(proyecto);
    }

    public async Task DeleteAsync(int id)
    {
        await _proyectoRepository.DeleteAsync(id);
    }
}