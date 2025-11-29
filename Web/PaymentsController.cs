using Microsoft.AspNetCore.Mvc;
using PaymentsService.Domain;

namespace PaymentsService.Web;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentRepository _repository;

    public PaymentsController(IPaymentRepository repository)
    {
        _repository = repository;
    }

    // Crear pago
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Payment payment)
    {
        await _repository.AddAsync(payment);
        return Ok(payment);
    }

    // Obtener pago por Id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var payment = await _repository.GetByIdAsync(id);
        if (payment is null) return NotFound();
        return Ok(payment);
    }

    // Listar todos los pagos
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var payments = await _repository.GetAllAsync();
        return Ok(payments);
    }

    // Actualizar pago
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Payment payment)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();

        await _repository.UpdateAsync(payment);
        return Ok(payment);
    }

    // Eliminar pago
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

