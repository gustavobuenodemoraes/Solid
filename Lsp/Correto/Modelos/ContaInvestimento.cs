namespace Lsp.Correto.Modelos;

using Lsp.Correto.Abstracoes;

/// <summary>
/// LSP RESPEITADO:
/// A ContaInvestimento implementa apenas IConta (pois só recebe depósitos/aportes).
/// Ela nunca finge que sabe sacar, evitando exceções em tempo de execução.
/// </summary>
public class ContaInvestimento : IConta
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor inválido para aporte.");
        Saldo += valor;
    }

    public void RenderJuros(decimal taxaPercentual)
    {
        Saldo += Saldo * (taxaPercentual / 100);
    }
}