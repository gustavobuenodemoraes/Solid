namespace Dip.Correto.Abstracoes;

public interface IRepositorioPagamento
{
    Task SalvarPagamentoAsync(string funcionario, decimal valorLiquido);
}