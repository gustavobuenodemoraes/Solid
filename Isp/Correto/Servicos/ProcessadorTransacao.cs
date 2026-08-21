namespace Isp.Correto.Servicos;

using Isp.Correto.Abstracoes;

public class ProcessadorTransacao
{
    // O processador só exige ITransacionavel. Ele não precisa forçar quem o chama a ser um banco inteiro.
    public void ExecutarCobranca(ITransacionavel terminal, decimal valor)
    {
        terminal.ProcessarPagamento(valor);
    }
}