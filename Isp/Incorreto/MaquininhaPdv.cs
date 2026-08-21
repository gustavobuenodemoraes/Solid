namespace Isp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO ISP:
/// Uma maquininha POS/PDV simples de cartão só precisa processar pagamento.
/// Como a interface é única e monolítica, a maquininha é forçada a implementar métodos
/// que ela não possui capacidade de executar, lançando NotImplementedException.
/// </summary>
public class MaquininhaPdv : IContratoBancarioGordo
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"[PDV] Pagamento de R$ {valor:N2} processado via chip/contactless.");
    }

    public void ValidarBiometriaFacial(byte[] foto)
    {
        // A maquininha não tem câmera nem suporte a biometria!
        throw new NotImplementedException("Hardware do PDV não possui câmera para validação facial.");
    }

    public void SolicitarEmprestimo(decimal valor)
    {
        // Uma maquininha não faz originação de crédito!
        throw new NotImplementedException("Terminal de pagamento não contrata linhas de crédito.");
    }

    public void ImprimirComprovantePapel()
    {
        Console.WriteLine("[PDV] Imprimindo comprovante térmico do lojista...");
    }
}