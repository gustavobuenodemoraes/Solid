namespace Isp.Correto.Modelos;

using Isp.Correto.Abstracoes;

/// <summary>
/// Um ATM bancário completo pode compor múltiplas interfaces pequenas e específicas.
/// </summary>
public class TerminalAutoatendimento : ITransacionavel, IAutenticavelBiometria, IFinanciavel, IEmissorComprovante
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"[ATM Banco] Pagamento de boleto de R$ {valor:N2} compensado.");
    }

    public bool ValidarBiometria(byte[] dadosBiometricos)
    {
        Console.WriteLine("[ATM Banco] Leitura biométrica validada na base de segurança.");
        return true;
    }

    public void SolicitarEmprestimo(decimal valor)
    {
        Console.WriteLine($"[ATM Banco] Contrato de crédito pessoal de R$ {valor:N2} pré-aprovado.");
    }

    public void ImprimirComprovante()
    {
        Console.WriteLine("[ATM Banco] Comprovante detalhado emitido com sucesso.");
    }
}