using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProyectosController : ControllerBase
{
    private readonly IProyectoRepository _proyectoRepository;
    private readonly IMapper _mapper;

    public ProyectosController(IProyectoRepository proyectoRepository, IMapper mapper)
    {
        _proyectoRepository = proyectoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProyectos()
    {
        var proyectos = await _proyectoRepository.GetAllAsync();
        return Ok(proyectos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProyecto(int id)
    {
        var proyecto = await _proyectoRepository.GetByIdAsync(id);
        if (proyecto == null)
        {
            return NotFound();
        }
        return Ok(proyecto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProyecto([FromBody] Proyecto proyecto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _proyectoRepository.AddAsync(proyecto);
        return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProyecto(int id, [FromBody] Proyecto proyecto)
    {
        if (id != proyecto.Id)
        {
            return BadRequest();
        }

        await _proyectoRepository.UpdateAsync(proyecto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProyecto(int id)
    {
        await _proyectoRepository.DeleteAsync(id);
        return NoContent();
    }
}
