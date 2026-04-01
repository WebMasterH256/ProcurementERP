using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("(auth)")]
public class AuthController : ControllerBase
{
	public class LoginRequest
	{
		public string Email {get; set;}
		public string Senha {get; set;}
	}

	private readonly IUsuarioService _us;
	private readonly IConfiguration _config;

	public AuthController(IUsuarioService us, IConfiguration config)
	{
		_us = us;
		_config = config;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var usuario = await _us.GetByEmailAsync(request.Email);
		if (usuario == null || usuario.Senha != request.Senha)
			return Unauthorized();

		var claims = new[]
		{
			new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
			new Claim(ClaimTypes.Email, usuario.Email),
			new Claim(ClaimTypes.Role, usuario.Cargo.ToString())
		};

		var key = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: _config["Jwt:Issuer"],
			audience: _config["Jwt:Audience"],
			claims: claims,
			expires: DateTime.UtcNow.AddHours(8),
			signingCredentials: creds);

		return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
	}
}