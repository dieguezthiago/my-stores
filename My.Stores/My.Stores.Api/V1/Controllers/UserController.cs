using Microsoft.AspNetCore.Mvc;

namespace My.Stores.Api.V1.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(new List<User>
        {
            new User(Guid.NewGuid(), Guid.NewGuid().ToString()),
            new User(Guid.NewGuid(), Guid.NewGuid().ToString()),
            new User(Guid.NewGuid(), Guid.NewGuid().ToString()),
            new User(Guid.NewGuid(), Guid.NewGuid().ToString())
        });
    }
}

public record User(Guid Id, string Username);