namespace Lsp.Correto.Abstracoes;

public interface IContaSaque : IConta
{
    void Sacar(decimal valor);
}