namespace Dip.Correto.Infraestrutura;

using Dip.Correto.Abstracoes;

public class ServicoMensageriaSqs : IServicoMensageria
{
    public Task NotificarPagamentoAsync(string destinatario, decimal valorLiquido)
    {
        Console.WriteLine($"[AWS SQS / Evento] Mensagem de holerite publicada na fila para {destinatario}.");
        return Task.CompletedTask;
    }
}