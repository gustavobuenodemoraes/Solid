namespace Ocp.Correto.Modelos;

public record ResultadoPagamento(bool Sucesso, string TransacaoId, string Mensagem);