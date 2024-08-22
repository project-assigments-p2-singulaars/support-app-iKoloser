using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupportAppV3.Models;
using SupportAppV3.Repository;

namespace SupportAppV3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthController(IUsuarioRepository usuarioRepository, IConfiguration configuration, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var usuario = await _usuarioRepository.GetByEmailAsync(loginModel.Email);
        if (usuario == null || !VerifyPassword(loginModel.Password, usuario.PasswordHash))
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(usuario);
        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private bool VerifyPassword(string inputPassword, string storedPasswordHash)
    {
        // Implement password verification logic
        return BCrypt.Net.BCrypt.Verify(inputPassword, storedPasswordHash);
    }
}
