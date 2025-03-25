using Microsoft.AspNetCore.Mvc;
using AmadeusAPI.Models;
using AmadeusAPI.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var user = new IdentityUser
        {
            UserName = request.Usuario
        };
        var result = _authService.Register(request.Usuario, request.email);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginRequest request)
{
    var (success, token, expiration) = await _authService.ValidateUserAndGenerateToken(request.Email);
    
    if (success)
    {
        return Ok(new AuthResponse
        {
            Token = token,
            Expiration = expiration
        });
    }
    return Unauthorized();
}

public class LoginRequest
{
    public string Email { get; set; }
}


    [HttpGet("protected")]
    [Authorize]
    public IActionResult Protected()
    {

        return Ok(new { message = "This is a protected endpoint." });
    }
}
public class RegisterRequest
{
    public string Usuario { get; set; }
    public string Password { get; set; }
}
public class LoginRequest
{
    public string Usuario { get; set; }
    public string Password { get; set; }
}