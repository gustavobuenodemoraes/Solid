namespace Ocp.Incorreto;

public class Pedido
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Valor { get; set; }
    public TipoPagamento Tipo { get; set; }
}