namespace Isp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO ISP:
/// Esta interface é "gorda" e monolítica. Ela mistura transação financeira,
/// autenticação biométrica, solicitação de empréstimo e impressão física de recibos.
/// </summary>
public interface IContratoBancarioGordo
{
    void ProcessarPagamento(decimal valor);
    void ValidarBiometriaFacial(byte[] foto);
    void SolicitarEmprestimo(decimal valor);
    void ImprimirComprovantePapel();
}