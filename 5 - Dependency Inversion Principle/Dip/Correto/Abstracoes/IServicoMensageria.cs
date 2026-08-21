namespace Dip.Correto.Abstracoes;

public interface IServicoMensageria
{
    Task NotificarPagamentoAsync(string destinatario, decimal valorLiquido);
}