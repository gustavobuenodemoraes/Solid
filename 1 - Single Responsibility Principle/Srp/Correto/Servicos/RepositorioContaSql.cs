namespace Srp.Correto.Servicos;

using Srp.Correto.Abstracoes;
using Srp.Correto.ObjetosDeValor;

public class RepositorioContaSql : IRepositorioConta
{
    public Task SalvarContaAsync(string nome, string email, Cpf cpf, decimal depositoInicial)
    {
        // Responsabilidade única: persistência no banco de dados
        Console.WriteLine($"[Banco de Dados] Conta de {nome} (CPF: {cpf.Valor}) salva com sucesso.");
        return Task.CompletedTask;
    }
}
