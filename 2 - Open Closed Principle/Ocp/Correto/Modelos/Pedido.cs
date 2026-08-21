namespace Ocp.Correto.Modelos;

public record Pedido(Guid Id, decimal Valor, TipoPagamento Tipo);