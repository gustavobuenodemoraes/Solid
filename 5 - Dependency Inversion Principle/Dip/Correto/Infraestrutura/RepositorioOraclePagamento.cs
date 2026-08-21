namespace Dip.Correto.Infraestrutura;

using Dip.Correto.Abstracoes;

public class RepositorioOraclePagamento : IRepositorioPagamento
{
    public Task SalvarPagamentoAsync(string funcionario, decimal valorLiquido)
    {
        Console.WriteLine($"[Banco Oracle] Transação PL/SQL executada para {funcionario} no valor de R$ {valorLiquido:N2}.");
        return Task.CompletedTask;
    }
}