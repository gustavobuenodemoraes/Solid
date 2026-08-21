namespace Lsp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO LSP:
/// Esta classe herda de ContaBancaria, mas NÃO pode permitir saques livres (regra de negócio/bloqueio judicial).
/// Ao lançar uma exceção inesperada ou alterar a pré-condição da classe pai, ela quebra qualquer código
/// polimórfico que espera que toda ContaBancaria consiga executar Sacar().
/// </summary>
public class ContaPoupancaSalario : ContaBancaria
{
    public override void Sacar(decimal valor)
    {
        // Quebra o princípio da substituição de Liskov!
        throw new NotSupportedException("Contas salário bloqueadas não permitem saques diretos no caixa.");
    }
}