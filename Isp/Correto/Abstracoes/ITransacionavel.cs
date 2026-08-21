namespace Isp.Correto.Abstracoes;

public interface ITransacionavel
{
    void ProcessarPagamento(decimal valor);
}