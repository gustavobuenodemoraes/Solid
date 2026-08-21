namespace Lsp.Correto.Servicos;

using Lsp.Correto.Abstracoes;

public class ServicoTransferencia
{
    // Exige estritamente IContaSaque na origem e IConta no destino (LSP 100% seguro)
    public void Transferir(IContaSaque contaOrigem, IConta contaDestino, decimal valor)
    {
        contaOrigem.Sacar(valor);
        contaDestino.Depositar(valor);
        Console.WriteLine($"[Transferência] R$ {valor:N2} transferidos com sucesso. Novo saldo origem: R$ {contaOrigem.Saldo:N2} | Saldo destino: R$ {contaDestino.Saldo:N2}");
    }
}