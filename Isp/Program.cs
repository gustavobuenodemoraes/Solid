using Isp.Correto.Abstracoes;
using Isp.Correto.Modelos;
using Isp.Correto.Servicos;
using Incorreto = Isp.Incorreto;

Console.WriteLine("=== Princípio da Segregação de Interfaces (ISP - Interface Segregation Principle) ===\n");

// 1. Executando o modelo incorreto (Interface Gorda forçando implementação indevida)
Console.WriteLine("--- 1. Executando Modo Incorreto (Violando ISP) ---");
Incorreto.IContratoBancarioGordo terminalIncorreto = new Incorreto.MaquininhaPdv();
terminalIncorreto.ProcessarPagamento(75.50m);

try
{
    Console.WriteLine("Tentando validar biometria em hardware sem suporte...");
    terminalIncorreto.ValidarBiometriaFacial(new byte[0]); // Lança NotImplementedException!
}
catch (NotImplementedException ex)
{
    Console.WriteLine($"❌ Violação de ISP detectada: {ex.Message}\n");
}

Console.WriteLine("------------------------------------------------------------------------\n");

// 2. Executando o modelo correto (Interfaces granulares e coesas)
Console.WriteLine("--- 2. Executando Modo Correto (ISP Respeitado) ---");

var processador = new ProcessadorTransacao();

// A maquininha só assina o contrato do que sabe fazer
var pdv = new MaquininhaPdvSimples();
processador.ExecutarCobranca(pdv, 150.00m);
pdv.ImprimirComprovante();

Console.WriteLine();

// O ATM assina múltiplos contratos de acordo com sua capacidade real
var atm = new TerminalAutoatendimento();
atm.ValidarBiometria(new byte[16]);
processador.ExecutarCobranca(atm, 1200.00m);
atm.SolicitarEmprestimo(5000.00m);
atm.ImprimirComprovante();

Console.WriteLine("\nOperações executadas com interfaces segregadas e sem exceções fantasmas!");