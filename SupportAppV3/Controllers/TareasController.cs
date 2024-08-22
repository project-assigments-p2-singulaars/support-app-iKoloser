using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ITareaRepository _tareaRepository;
    private readonly IMapper _mapper;

    public TareasController(ITareaRepository tareaRepository, IMapper mapper)
    {
        _tareaRepository = tareaRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTareas()
    {
        var tareas = await _tareaRepository.GetAllAsync();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTarea(int id)
    {
        var tarea = await _tareaRepository.GetByIdAsync(id);
        if (tarea == null)
        {
            return NotFound();
        }
        return Ok(tarea);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTarea([FromBody] Tarea tarea)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _tareaRepository.AddAsync(tarea);
        return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTarea(int id, [FromBody] Tarea tarea)
    {
        if (id != tarea.Id)
        {
            return BadRequest();
        }

        await _tareaRepository.UpdateAsync(tarea);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarea(int id)
    {
        await _tareaRepository.DeleteAsync(id);
        return NoContent();
    }
}
