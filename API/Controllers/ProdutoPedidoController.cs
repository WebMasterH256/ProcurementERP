namespace API.Controllers;

using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("produto-pedido")]
public class ProdutoPedidoController : ControllerBase
{
	private readonly IProdutoPedidoService _pps;

	public ProdutoPedidoController(IProdutoPedidoService pps) { _pps = pps; }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var pedido = await _pps.GetByIdAsync(id);
		if (pedido == null) return NotFound();
		return Ok(pedido);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var produtoPedidos = await _pps.GetAllAsync();
		if (produtoPedidos == null) return NotFound();
		return Ok(produtoPedidos);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] ProdutoPedido pedido)
	{
		await _pps.AddAsync(pedido);
		return CreatedAtAction(nameof(GetById),
			new { id = pedido.Id }, pedido);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] ProdutoPedido pedido)
	{
		if (id != pedido.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(pedido);
		await _pps.UpdateAsync(pedido);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _pps.GetByIdAsync(id) == null) return NotFound();
		await _pps.DeleteAsync(id);
		return NoContent();
	}
}
