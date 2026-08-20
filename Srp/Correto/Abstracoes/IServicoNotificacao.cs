namespace Srp.Correto.Abstracoes;

public interface IServicoNotificacao
{
    Task EnviarEmailBoasVindasAsync(string email, string nome);
}