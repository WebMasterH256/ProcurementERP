namespace API.Controllers;

using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("departamento")]
public class DepartamentoController : ControllerBase
{
	private readonly IDepartamentoService _ds;

	public DepartamentoController(IDepartamentoService ds) { _ds = ds; }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var departamento = await _ds.GetByIdAsync(id);
		if (departamento == null) return NotFound();
		return Ok(departamento);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var departamentos = await _ds.GetAllAsync();
		if (departamentos == null) return NotFound();
		return Ok(departamentos);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Departamento departamento)
	{
		await _ds.AddAsync(departamento);
		return CreatedAtAction(nameof(GetById),
			new { id = departamento.Id }, departamento);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Departamento departamento)
	{
		if (id != departamento.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(departamento);
		await _ds.UpdateAsync(departamento);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _ds.GetByIdAsync(id) == null) return NotFound();
		await _ds.DeleteAsync(id);
		return NoContent();
	}
}
