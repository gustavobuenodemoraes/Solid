namespace Lsp.Incorreto;

public class ContaCorrente : ContaBancaria
{
    public decimal TaxaManutencao { get; set; } = 15.00m;

    public override void Sacar(decimal valor)
    {
        // Funciona perfeitamente como substituto de ContaBancaria
        base.Sacar(valor);
    }
}