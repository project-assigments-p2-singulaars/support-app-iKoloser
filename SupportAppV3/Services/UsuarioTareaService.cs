using AutoMapper;
using SupportAppV3.DTOs;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Services;

public class UsuarioTareaService : IUsuarioTareaService
{
    private readonly IUsuarioTareaRepository _usuarioTareaRepository;
    private readonly IMapper _mapper;

    public UsuarioTareaService(IUsuarioTareaRepository usuarioTareaRepository, IMapper mapper)
    {
        _usuarioTareaRepository = usuarioTareaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioTareaDto>> GetAllAsync()
    {
        var usuarioTareas = await _usuarioTareaRepository.GetAllAsync();
        return usuarioTareas.Select(ut => _mapper.Map<UsuarioTareaDto>(ut));
    }

    public async Task<UsuarioTareaDto> GetByIdAsync(int usuarioId, int tareaId, int rolId)
    {
        var usuarioTarea = await _usuarioTareaRepository.GetByIdAsync(usuarioId, tareaId, rolId);
        return _mapper.Map<UsuarioTareaDto>(usuarioTarea);
    }

    public async Task AddAsync(UsuarioTareaDto usuarioTareaDto)
    {
        var usuarioTarea = _mapper.Map<UsuarioTarea>(usuarioTareaDto);
        await _usuarioTareaRepository.AddAsync(usuarioTarea);
    }

    public async Task UpdateAsync(UsuarioTareaDto usuarioTareaDto)
    {
        var usuarioTarea = _mapper.Map<UsuarioTarea>(usuarioTareaDto);
        _usuarioTareaRepository.Update(usuarioTarea);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int usuarioId, int tareaId, int rolId)
    {
        var usuarioTarea = await _usuarioTareaRepository.GetByIdAsync(usuarioId, tareaId, rolId);
        if (usuarioTarea != null)
        {
            _usuarioTareaRepository.Delete(usuarioTarea);
        }
        await Task.CompletedTask;
    }
}