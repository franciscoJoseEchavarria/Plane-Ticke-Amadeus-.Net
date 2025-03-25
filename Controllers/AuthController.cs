using Microsoft.AspNetCore.Mvc;
using AmadeusAPI.Models;
using AmadeusAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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
public async Task<IActionResult> Login([FromBody] LoginRequest request)
{
    var (success, token, expiration) = await _authService.ValidateUserAndGenerateToken(request.Email);
    
    if (success)
    {
        // Store token in session
        HttpContext.Session.SetString("tokenSession", token);

        return Ok(new AuthResponse
        {
            Token = token,
            Expiration = expiration
        });
    }
    return Unauthorized();
}

[HttpGet("getToken")]
public IActionResult GetToken()
{
    var token = HttpContext.Session.GetString("tokenSession");
    if (string.IsNullOrEmpty(token))
    {
        return NotFound("No token found in session");
    }
    return Ok(new { token });
}

    [HttpGet("protected")]
    [Authorize]
    public IActionResult Protected()
    {

        return Ok(new { message = "This is a protected endpoint." });
    }
}

