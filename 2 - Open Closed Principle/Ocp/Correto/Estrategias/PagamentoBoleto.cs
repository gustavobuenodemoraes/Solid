namespace Ocp.Correto.Estrategias;

using Ocp.Correto.Abstracoes;
using Ocp.Correto.Modelos;

public class PagamentoBoleto : IEstrategiaPagamento
{
    public TipoPagamento Tipo => TipoPagamento.Boleto;

    public Task<ResultadoPagamento> ProcessarAsync(Pedido pedido)
    {
        Console.WriteLine($"[BOLETO] Registrando título bancário no convênio para o valor de R$ {pedido.Valor:N2}.");
        return Task.FromResult(new ResultadoPagamento(true, Guid.NewGuid().ToString(), "Linha digitável emitida com sucesso."));
    }
}