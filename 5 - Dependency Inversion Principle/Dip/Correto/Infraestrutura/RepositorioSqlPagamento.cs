namespace Dip.Correto.Infraestrutura;

using Dip.Correto.Abstracoes;

public class RepositorioSqlPagamento : IRepositorioPagamento
{
    public Task SalvarPagamentoAsync(string funcionario, decimal valorLiquido)
    {
        Console.WriteLine($"[Banco SQL Server] Registro de R$ {valorLiquido:N2} para {funcionario} salvo com sucesso.");
        return Task.CompletedTask;
    }
}