using Microsoft.AspNetCore.Mvc;
using TaskFlow2.API.Services;

namespace TaskFlow2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;
    public AuthController(AuthService auth) => _auth = auth;

    [HttpPost("register")]
    public async Task<IActionResult> Register(LoginDto dto)
    {
        var token = await _auth.RegisterAsync(dto.Email, dto.Password);
        return token is null
            ? BadRequest("Email already in use")
            : Ok(new { token });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var token = _auth.LoginAsync(dto.Email, dto.Password);
        return token is null
            ? Unauthorized("Invalid email or password")
            : Ok(new { token });
    }
}

public record LoginDto(string Email, string Password);