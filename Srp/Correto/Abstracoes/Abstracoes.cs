namespace Srp.Correto.Abstracoes;

using Srp.Correto.ObjetosDeValor;

public interface IServicoAnaliseFraude
{
    Task<bool> EstaAprovadoAsync(Cpf cpf, decimal depositoInicial);
}

public interface IRepositorioConta
{
    Task SalvarContaAsync(string nome, string email, Cpf cpf, decimal depositoInicial);
}

public interface IServicoNotificacao
{
    Task EnviarEmailBoasVindasAsync(string email, string nome);
}