using SupportAppV3.DTOs;

namespace SupportAppV3.Mappings;

using AutoMapper;
using SupportAppV3.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Proyecto, ProyectoDto>();
        CreateMap<Tarea, TareaDto>();
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<Rol, RolDto>();

        CreateMap<ProyectoDto, Proyecto>();
        CreateMap<TareaDto, Tarea>();
        CreateMap<UsuarioDto, Usuario>();
        CreateMap<RolDto, Rol>();
    }
}
