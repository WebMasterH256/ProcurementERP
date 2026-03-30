namespace API.Controllers;

using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("pedido")]
public class PedidoController : ControllerBase
{
	private readonly IPedidoService _ps;

	public PedidoController(IPedidoService pps) { _ps = pps; }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var pedido = await _ps.GetByIdAsync(id);
		if (pedido == null) return NotFound();
		return Ok(pedido);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var Pedidos = await _ps.GetAllAsync();
		if (Pedidos == null) return NotFound();
		return Ok(Pedidos);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Pedido pedido)
	{
		await _ps.AddAsync(pedido);
		return CreatedAtAction(nameof(GetById),
			new { id = pedido.Id }, pedido);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
	{
		if (id != pedido.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(pedido);
		await _ps.UpdateAsync(pedido);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (await _ps.GetByIdAsync(id) == null) return NotFound();
		await _ps.DeleteAsync(id);
		return NoContent();
	}
}
