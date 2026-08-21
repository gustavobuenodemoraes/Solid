namespace Ocp.Correto.Estrategias;

using Ocp.Correto.Abstracoes;
using Ocp.Correto.Modelos;

public class PagamentoCartaoCredito : IEstrategiaPagamento
{
    public TipoPagamento Tipo => TipoPagamento.CartaoCredito;

    public Task<ResultadoPagamento> ProcessarAsync(Pedido pedido)
    {
        Console.WriteLine($"[CARTÃO] Tokenizando cartão e processando transação de R$ {pedido.Valor:N2} na Adquirente.");
        return Task.FromResult(new ResultadoPagamento(true, Guid.NewGuid().ToString(), "Autorização de crédito aprovada."));
    }
}