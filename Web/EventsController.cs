using Microsoft.AspNetCore.Mvc;
using EventsService.Domain;

namespace EventsService.Web;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _repository;

    public EventsController(IEventRepository repository)
    {
        _repository = repository;
    }

    // Crear evento
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Event ev)
    {
        await _repository.AddAsync(ev);
        return Ok(ev);
    }

    // Obtener evento por Id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var ev = await _repository.GetByIdAsync(id);
        if (ev is null) return NotFound();
        return Ok(ev);
    }

    // Listar todos los eventos
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var events = await _repository.GetAllAsync();
        return Ok(events);
    }

    // Actualizar evento
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Event ev)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();

        await _repository.UpdateAsync(ev);
        return Ok(ev);
    }

    // Eliminar evento
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
