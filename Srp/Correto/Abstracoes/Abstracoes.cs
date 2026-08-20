namespace Srp.Correto.Abstracoes;

using Srp.Correto.ObjetosDeValor;

public interface IServicoAnaliseFraude
{
    Task<bool> EstaAprovadoAsync(Cpf cpf, decimal depositoInicial);
}
