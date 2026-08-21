namespace Isp.Correto.Modelos;

using Isp.Correto.Abstracoes;

/// <summary>
/// ISP RESPEITADO:
/// A maquininha implementa estritamente o que suporta (Transacionar e Imprimir).
/// Não é obrigada a conhecer biometria nem empréstimos.
/// </summary>
public class MaquininhaPdvSimples : ITransacionavel, IEmissorComprovante
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"[PDV Simples] Transação de R$ {valor:N2} aprovada com sucesso.");
    }

    public void ImprimirComprovante()
    {
        Console.WriteLine("[PDV Simples] Via do cliente impressa na bobina.");
    }
}