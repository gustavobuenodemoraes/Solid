namespace Ocp.Correto.Estrategias;

using Ocp.Correto.Abstracoes;
using Ocp.Correto.Modelos;

/// <summary>
/// PROVA DO OCP:
/// Adicionamos uma nova forma de pagamento criando apenas esta classe.
/// O ProcessadorPagamento não precisou ser alterado nem recompilado com novos ifs.
/// </summary>
public class PagamentoCripto : IEstrategiaPagamento
{
    public TipoPagamento Tipo => TipoPagamento.Cripto;

    public Task<ResultadoPagamento> ProcessarAsync(Pedido pedido)
    {
        Console.WriteLine($"[CRIPTO] Gerando carteira temporária e monitorando blockchain para R$ {pedido.Valor:N2}.");
        return Task.FromResult(new ResultadoPagamento(true, Guid.NewGuid().ToString(), "Hash de transação gerado na rede."));
    }
}