using Microsoft.AspNetCore.Mvc;
using AmadeusAPI.services;
using AmadeusAPI.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Authorization;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Usuario == "admin" && request.Password == "1234")
        {
            var token = _authService.GenerateToken(request.Usuario);
            return Ok(new { token });
        }
        return Unauthorized();
    }
    [HttpGet("protected")]
    [Authorize]  
    public IActionResult Protected()
    {
        
        return Ok(new { message = "This is a protected endpoint." });
    }
}
public class LoginRequest
{
    public string Usuario { get; set; }
    public string Password { get; set; }
}