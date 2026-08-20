namespace Ocp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO OCP:
/// Toda vez que o negócio pedir um novo meio de pagamento (ex: Débito, Cripto, Carteira Digital),
/// este arquivo precisará ser MODIFICADO, aumentando o risco de quebrar os pagamentos que já funcionam.
/// </summary>
public class ProcessadorPagamento
{
    public void Processar(Pedido pedido)
    {
        if (pedido.Tipo == TipoPagamento.Pix)
        {
            Console.WriteLine($"[PIX] Gerando QR Code estático/dinâmico no valor de R$ {pedido.Valor:N2}...");
            // Lógica e regras específicas do Banco Central / Chave Pix
        }
        else if (pedido.Tipo == TipoPagamento.CartaoCredito)
        {
            Console.WriteLine($"[CARTÃO] Conectando à adquirente e capturando limite de R$ {pedido.Valor:N2}...");
            // Lógica de tokenização, validação de CVV, antifraude de cartão
        }
        else if (pedido.Tipo == TipoPagamento.Boleto)
        {
            Console.WriteLine($"[BOLETO] Emitindo linha digitável e código de barras para R$ {pedido.Valor:N2}...");
            // Lógica de cálculo de vencimento, juros e registro bancário
        }
        else
        {
            throw new NotSupportedException($"Forma de pagamento '{pedido.Tipo}' não suportada.");
        }
    }
}