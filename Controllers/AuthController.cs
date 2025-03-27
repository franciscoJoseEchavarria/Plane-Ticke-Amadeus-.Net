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

    // Constructor que inyecta el servicio de autenticación
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    // Endpoint para el inicio de sesión
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Valida el usuario y genera un token JWT
        var (success, token, expiration) = await _authService.ValidateUserAndGenerateToken(request.Email);
        var formattedExpiration = expiration.ToString("yyyy-MM-dd HH:mm:ss");
        
        if (success)
        {
            // Almacena el token en la sesión
            HttpContext.Session.SetString("tokenSession", token);

            // Devuelve la respuesta de autenticación con el token y la fecha de expiración
            return Ok(new AuthResponse
            {
                Token = token,
                Expiration = formattedExpiration
                
            });
        }
        // Si la validación falla, devuelve una respuesta no autorizada
        return Unauthorized();
    }

    // Endpoint para obtener el token almacenado en la sesión
    [HttpGet("getToken")]
    public IActionResult GetToken()
    {
        // Obtiene el token de la sesión
        var token = HttpContext.Session.GetString("tokenSession");
        if (string.IsNullOrEmpty(token))
        {
            // Si no se encuentra el token, devuelve una respuesta 404
            return NotFound("No token found in session");
        }
        // Devuelve el token encontrado en la sesión
        return Ok(new { token });
    }

    // Endpoint protegido que requiere autenticación
    [HttpGet("protected")]
    [Authorize]
    public IActionResult Protected()
    {
        // Devuelve un mensaje indicando que el endpoint está protegido
        return Ok(new { message = "This is a protected endpoint." });
    }
}