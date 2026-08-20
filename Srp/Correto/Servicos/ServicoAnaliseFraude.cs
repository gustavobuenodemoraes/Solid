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

public class RepositorioContaSql : IRepositorioConta
{
    public Task SalvarContaAsync(string nome, string email, Cpf cpf, decimal depositoInicial)
    {
        // Responsabilidade única: persistência no banco de dados
        Console.WriteLine($"[Banco de Dados] Conta de {nome} (CPF: {cpf.Valor}) salva com sucesso.");
        return Task.CompletedTask;
    }
}

public class ServicoNotificacaoEmail : IServicoNotificacao
{
    public Task EnviarEmailBoasVindasAsync(string email, string nome)
    {
        // Responsabilidade única: comunicação e notificação
        Console.WriteLine($"[Notificação] E-mail de boas-vindas enviado para {email}.");
        return Task.CompletedTask;
    }
}