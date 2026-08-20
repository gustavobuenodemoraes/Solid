using Srp.Correto.Abstracoes;
using Srp.Correto.Servicos;
using Incorreto = Srp.Incorreto;

Console.WriteLine("=== Demonstração do Princípio da Responsabilidade Única (SRP) ===\n");

// 1. Execução do modelo incorreto
Console.WriteLine("--- 1. Executando Modo Incorreto (God Class) ---");
var servicoIncorreto = new Incorreto.ServicoAberturaConta();
servicoIncorreto.AbrirConta("Carlos Silva", "carlos@email.com", "12345678901", 500m);

Console.WriteLine("\n------------------------------------------------\n");

// 2. Execução do modelo correto (Modular e Desacoplado)
Console.WriteLine("--- 2. Executando Modo Correto (Responsabilidades Isoladas) ---");
IServicoAnaliseFraude analiseFraude = new ServicoAnaliseFraude();
IRepositorioConta repositorio = new RepositorioContaSql();
IServicoNotificacao notificacao = new ServicoNotificacaoEmail();

var servicoCorreto = new ServicoAberturaConta(analiseFraude, repositorio, notificacao);
await servicoCorreto.AbrirContaAsync("Ana Souza", "ana@email.com", "98765432100", 1200m);

Console.WriteLine("\nProcesso finalizado com sucesso!");