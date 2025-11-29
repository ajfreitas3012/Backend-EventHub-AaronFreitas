using Microsoft.AspNetCore.Mvc;
using Infrastructure.Persistence;
using UsersService.Domain;

namespace UsersService.Web;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // Crear usuario
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto dto)
    {
        var user = new User(dto.Id, dto.Name, new Email(dto.Email));

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok(user);
    }

    // Actualizar usuario
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();

        var updatedUser = new User(dto.Id, dto.Name, new Email(dto.Email));

        _db.Users.Update(updatedUser);
        await _db.SaveChangesAsync();

        return Ok(updatedUser);
    }

    // Obtener usuario por Id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();
        return Ok(user);
    }
}
