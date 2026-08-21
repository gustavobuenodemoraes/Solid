namespace Ocp.Correto.Servicos;

using Ocp.Correto.Abstracoes;
using Ocp.Correto.Modelos;

public class ProcessadorPagamento
{
    private readonly IReadOnlyDictionary<TipoPagamento, IEstrategiaPagamento> _estrategias;

    // Recebe todas as implementações injetadas dinamicamente e as indexa pelo tipo
    public ProcessadorPagamento(IEnumerable<IEstrategiaPagamento> estrategias)
    {
        _estrategias = estrategias.ToDictionary(e => e.Tipo);
    }

    public async Task<ResultadoPagamento> ProcessarAsync(Pedido pedido)
    {
        if (!_estrategias.TryGetValue(pedido.Tipo, out var estrategia))
        {
            throw new NotSupportedException($"A forma de pagamento '{pedido.Tipo}' não possui estratégia registrada.");
        }

        return await estrategia.ProcessarAsync(pedido);
    }
}