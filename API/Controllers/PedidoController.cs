using Microsoft.AspNetCore.Authorization;

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

	[Authorize]
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var pedido = await _ps.GetByIdAsync(id);
		if (pedido == null) return NotFound();
		return Ok(pedido);
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var Pedidos = await _ps.GetAllAsync();
		if (Pedidos == null) return NotFound();
		return Ok(Pedidos);
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Pedido pedido)
	{
		await _ps.AddAsync(pedido);
		return CreatedAtAction(nameof(GetById),
			new { id = pedido.Id }, pedido);
	}

	[Authorize(Roles = "Gerente")]
	[HttpPut("{id}")]
	public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
	{
		if (id != pedido.Id) return BadRequest();
		ArgumentNullException.ThrowIfNull(pedido);
		await _ps.UpdateAsync(pedido);
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

	public class AtualizarStatusRequest
	{
		public StatusPedido NovoStatus { get; set; }
		public int UsuarioId { get; set; }
	}

	[Authorize (Roles = "Gerente")]
	[HttpPatch("{id}/status")]
	public async Task<IActionResult> AtualizarStatus(int id, [FromBody] AtualizarStatusRequest request)
	{
		var pedido = await _ps.GetByIdAsync(id);
		if (pedido == null) return NotFound();

		await _ps.UpdateStatusAsync(id, request.NovoStatus, request.UsuarioId);
		return NoContent();
	}
}
