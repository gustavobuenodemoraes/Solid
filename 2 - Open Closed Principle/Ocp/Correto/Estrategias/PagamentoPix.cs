namespace Ocp.Correto.Estrategias;

using Ocp.Correto.Abstracoes;
using Ocp.Correto.Modelos;

public class PagamentoPix : IEstrategiaPagamento
{
    public TipoPagamento Tipo => TipoPagamento.Pix;

    public Task<ResultadoPagamento> ProcessarAsync(Pedido pedido)
    {
        Console.WriteLine($"[PIX] Gerando QR Code instantâneo para o Pedido {pedido.Id} no valor de R$ {pedido.Valor:N2}.");
        return Task.FromResult(new ResultadoPagamento(true, Guid.NewGuid().ToString(), "Chave Pix validada via BACEN."));
    }
}