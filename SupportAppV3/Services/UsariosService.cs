using AutoMapper;
using SupportAppV3.DTOs;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Services;

public class UsuariosService : IUsuariosService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuariosService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return usuarios.Select(u => _mapper.Map<UsuarioDto>(u));
    }

    public async Task<UsuarioDto> GetByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task AddAsync(UsuarioDto usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task UpdateAsync(UsuarioDto usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
    }
}