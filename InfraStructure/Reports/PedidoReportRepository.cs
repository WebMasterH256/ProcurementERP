using Dapper;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InfraStructure.Reports;

public class PedidoReportRepository
{
	private readonly string _connectionString;

	public PedidoReportRepository(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("Server")!;
	}

	public async Task<IEnumerable<RelatorioPedido>> GetRelatorioAsync()
	{
		const string sql = @"
            SELECT 
                p.Id AS PedidoId,
                d.Nome AS Departamento,
                u.Nome AS Usuario,
                CASE p.Status
                    WHEN 0 THEN 'Aberto'
                    WHEN 1 THEN 'Finalizado'
                    WHEN 2 THEN 'Cancelado'
                END AS Status,
                p.Valor AS ValorTotal,
                p.Criacao AS DataCriacao
            FROM Pedido p
            INNER JOIN Departamento d ON p.DepartamentoId = d.Id
            INNER JOIN Usuario u ON p.UsuarioId = u.Id
            ORDER BY p.Criacao DESC";

		using var connection = new SqlConnection(_connectionString);
		return await connection.QueryAsync<RelatorioPedido>(sql);
	}
}