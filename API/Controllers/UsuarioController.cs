namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Interfaces;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
	private readonly IUsuarioService _us;

	public UsuarioController(IUsuarioService us) { _us = us; }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var usuario = await _us.GetByIdAsync(id);
		if (usuario == null) return NotFound();
		return Ok(usuario);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var usuarios = await _us.GetAllAsync();
		if (usuarios == null) return NotFound();
		return Ok(usuarios);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Usuario usuario)
	{
		await _us.AddAsync(usuario);
		return CreatedAtAction(nameof(GetById),
			new { id = usuario.Id }, usuario);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
	{
		if (id != usuario.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(usuario);
		await _us.UpdateAsync(usuario);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _us.GetByIdAsync(id) == null) return NotFound();
		await _us.DeleteAsync(id);
		return NoContent();
	}
}
