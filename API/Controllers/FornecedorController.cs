using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("fornecedor")]
public class FornecedorController : ControllerBase
{
	private readonly IFornecedorService _fs;

	public FornecedorController(IFornecedorService fs) { _fs = fs; }

	[Authorize]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var fornecedor = await _fs.GetByIdAsync(id);
		if (fornecedor == null) return NotFound();
		return Ok(fornecedor);
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var fornecedores = await _fs.GetAllAsync();
		if (fornecedores == null) return NotFound();
		return Ok(fornecedores);
	}

	[Authorize(Roles = "Gerente")]
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Fornecedor fornecedor)
	{
		await _fs.AddAsync(fornecedor);
		return CreatedAtAction(nameof(GetById),
			new { id = fornecedor.Id }, fornecedor);
	}

	[Authorize(Roles = "Gerente")]
	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Fornecedor fornecedor)
	{
		if (id != fornecedor.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(fornecedor);
		await _fs.UpdateAsync(fornecedor);
		return NoContent();
	}

	[Authorize(Roles = "Gerente")]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _fs.GetByIdAsync(id) == null) return NotFound();
		await _fs.DeleteAsync(id);
		return NoContent();
	}
}
