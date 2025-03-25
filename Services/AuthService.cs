using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using AmadeusAPI.Models;
using AmadeusAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AmadeusAPI.Services
{
    public class AuthService
{
    private readonly IConfiguration _config;
    private readonly AmadeusAPIDbContext _context;

    public AuthService(IConfiguration config, AmadeusAPIDbContext context)
    {
        _config = config;
        _context = context;
    }

    public async Task<(bool success, string token, DateTime expiration)> ValidateUserAndGenerateToken(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return (false, null, DateTime.MinValue);
        }

        var (token, expiration) = GenerateToken(email);
        return (true, token, expiration);
    }

    public (string token, DateTime expiration) GenerateToken(string email)
    {
        var expirationMinutes = _config.GetValue<int>("Jwt:ExpiryInMinutes");
        var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);
    
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "User")
        };
    
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
    }

}
}