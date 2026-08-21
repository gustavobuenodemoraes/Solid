using Dip.Correto.Abstracoes;
using Dip.Correto.Dominio;
using Dip.Correto.Infraestrutura;
using Microsoft.Extensions.DependencyInjection;
using Incorreto = Dip.Incorreto;

Console.WriteLine("=== Princípio da Inversão de Dependência (DIP - Dependency Inversion Principle) ===\n");

// 1. Executando o modelo incorreto (Acoplamento forte com operador 'new')
Console.WriteLine("--- 1. Executando Modo Incorreto (Violando DIP) ---");
var processadorIncorreto = new Incorreto.ProcessadorFolhaPagamento();
processadorIncorreto.Processar("Rodrigo Faro", "rodrigo@empresa.com", 8000m, 1800m);

Console.WriteLine("\n------------------------------------------------------------------------\n");

// 2. Executando o modelo correto (Injeção de Dependência via Container Nativo do .NET)
Console.WriteLine("--- 2. Executando Modo Correto (DIP com Container DI .NET 8) ---");

var colecaoServicos = new ServiceCollection();

// Registro das Abstrações e Implementações no Container de Inversão de Controle (IoC)
// Note que podemos trocar entre RepositorioSqlPagamento e RepositorioOraclePagamento alterando apenas esta linha:
// Simulando a leitura de uma configuração externa (appsettings.json / Environment Variable)
string provedorBanco = "Sql"; // ou "SqlServer"

if (provedorBanco.Equals("Oracle", StringComparison.OrdinalIgnoreCase))
{
    colecaoServicos.AddScoped<IRepositorioPagamento, RepositorioOraclePagamento>();
}
else
{
    colecaoServicos.AddScoped<IRepositorioPagamento, RepositorioSqlPagamento>();
}
colecaoServicos.AddScoped<IServicoMensageria, ServicoMensageriaSqs>();
colecaoServicos.AddTransient<ProcessadorFolhaPagamento>();

var provedorServicos = colecaoServicos.BuildServiceProvider();

// Resolução da dependência na raiz
using (var escopo = provedorServicos.CreateScope())
{
    var processadorCorreto = escopo.ServiceProvider.GetRequiredService<ProcessadorFolhaPagamento>();
    await processadorCorreto.ProcessarAsync("Mariana Lima", "mariana@empresa.com", 12500m, 2900m);
}

Console.WriteLine("\nFolha de pagamento processada de forma 100% desacoplada!");