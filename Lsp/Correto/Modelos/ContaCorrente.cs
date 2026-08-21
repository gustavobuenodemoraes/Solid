namespace Lsp.Correto.Modelos;

using Lsp.Correto.Abstracoes;

public class ContaCorrente : IContaSaque
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor inválido para depósito.");
        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor inválido para saque.");
        if (Saldo < valor) throw new InvalidOperationException("Saldo insuficiente.");
        Saldo -= valor;
    }
}