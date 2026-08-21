using Lsp.Correto.Abstracoes;
using Lsp.Correto.Modelos;
using Lsp.Correto.Servicos;
using Incorreto = Lsp.Incorreto;

Console.WriteLine("=== Princípio da Substituição de Liskov (LSP - Liskov Substitution Principle) ===\n");

// 1. Executando o modelo incorreto (Quebra em tempo de execução ao tentar substituir a classe pai)
Console.WriteLine("--- 1. Executando Modo Incorreto (Violando LSP) ---");
try
{
    Incorreto.ContaBancaria contaGenerica = new Incorreto.ContaPoupancaSalario();
    contaGenerica.Depositar(1000m);
    Console.WriteLine($"Saldo atual: R$ {contaGenerica.Saldo:N2}");

    Console.WriteLine("Tentando realizar saque polimórfico...");
    contaGenerica.Sacar(200m); // Lança NotSupportedException em tempo de execução!
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Falha de LSP detectada: {ex.Message}\n");
}

Console.WriteLine("------------------------------------------------------------------------\n");

// 2. Executando o modelo correto (Polimorfismo com contratos seguros)
Console.WriteLine("--- 2. Executando Modo Correto (LSP Respeitado) ---");

IContaSaque contaOrigem = new ContaCorrente();
contaOrigem.Depositar(500m);

IConta contaDestino = new ContaInvestimento();
contaDestino.Depositar(100m);

var servicoTransferencia = new ServicoTransferencia();
servicoTransferencia.Transferir(contaOrigem, contaDestino, 150m);

Console.WriteLine("\nOperação finalizada sem quebra de contratos!");