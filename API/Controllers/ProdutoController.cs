using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain;

[ApiController]
[Route("produto")]
public class ProdutoController : ControllerBase
{
	private readonly IProdutoService _ps;

	public ProdutoController(IProdutoService ps) {  _ps = ps; }

	[Authorize]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var produto = await _ps.GetByIdAsync(id);
		if (produto == null) return NotFound();
		return Ok(produto);
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var produtos = await _ps.GetAllAsync();
		if (produtos == null) return NotFound();
		return Ok(produtos);
	}

	[Authorize(Roles = "Gerente")]
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Produto produto)
	{
		await _ps.AddAsync(produto);
		return CreatedAtAction(nameof(GetById),
			new { id = produto.Id }, produto);
	}

	[Authorize(Roles = "Gerente")]
	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
	{
		if (id != produto.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(produto);
		await _ps.UpdateAsync(produto);
		return NoContent();
	}

	[Authorize(Roles = "Gerente")]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _ps.GetByIdAsync(id) == null) return NotFound();
		await _ps.DeleteAsync(id);
		return NoContent();
	}
}
