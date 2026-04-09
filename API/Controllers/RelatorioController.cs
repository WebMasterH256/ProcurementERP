namespace API.Controllers;

using InfraStructure.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("relatorio")]
public class RelatorioController : ControllerBase
{
	private readonly PedidoReportRepository _prr;

	public RelatorioController(PedidoReportRepository prr) { _prr = prr; }

	[HttpGet("pedidos")]
	public async Task<IActionResult> GetRelatorioPedidos()
	{
		var relatorio = await _prr.GetRelatorioAsync();
		return Ok(relatorio);
	}
}
