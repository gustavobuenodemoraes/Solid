namespace Srp.Correto.Servicos;

using Srp.Correto.Abstracoes;

public class ServicoNotificacaoEmail : IServicoNotificacao
{
    public Task EnviarEmailBoasVindasAsync(string email, string nome)
    {
        // Responsabilidade única: comunicação e notificação
        Console.WriteLine($"[Notificação] E-mail de boas-vindas enviado para {email}.");
        return Task.CompletedTask;
    }
}