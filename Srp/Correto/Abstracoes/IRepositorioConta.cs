namespace Srp.Correto.Abstracoes;

using Srp.Correto.ObjetosDeValor;

public interface IRepositorioConta
{
    Task SalvarContaAsync(string nome, string email, Cpf cpf, decimal depositoInicial);
}
