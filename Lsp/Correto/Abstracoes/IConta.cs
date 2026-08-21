namespace Lsp.Correto.Abstracoes;

public interface IConta
{
    decimal Saldo { get; }
    void Depositar(decimal valor);
}