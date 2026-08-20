namespace Srp.Correto.Servicos;

using Srp.Correto.Abstracoes;
using Srp.Correto.ObjetosDeValor;

public class ServicoAnaliseFraude : IServicoAnaliseFraude
{
    public Task<bool> EstaAprovadoAsync(Cpf cpf, decimal depositoInicial)
    {
        // Responsabilidade única: avaliar o risco da abertura de conta
        Console.WriteLine($"[Antifraude] Validando score e histórico do CPF: {cpf.Valor}");
        return Task.FromResult(depositoInicial > 0);
    }
}
