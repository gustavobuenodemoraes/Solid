namespace Ocp.Correto.Abstracoes;

using Ocp.Correto.Modelos;

public interface IEstrategiaPagamento
{
    TipoPagamento Tipo { get; }
    Task<ResultadoPagamento> ProcessarAsync(Pedido pedido);
}