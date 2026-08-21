namespace Lsp.Incorreto;

public class ContaBancaria
{
    public decimal Saldo { get; protected set; }

    public virtual void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do depósito deve ser positivo.");

        Saldo += valor;
    }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do saque deve ser positivo.");

        if (Saldo < valor)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo -= valor;
    }
}