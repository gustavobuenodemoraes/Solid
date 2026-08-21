namespace Dip.Correto.Dominio;

using Dip.Correto.Abstracoes;

/// <summary>
/// DIP RESPEITADO:
/// O processador depende estritamente das interfaces IRepositorioPagamento e IServicoMensageria.
/// Ele desconhece se o banco é SQL Server, Oracle ou se a notificação é via SQS ou E-mail.
/// </summary>
public class ProcessadorFolhaPagamento
{
    private readonly IRepositorioPagamento _repositorio;
    private readonly IServicoMensageria _mensageria;

    public ProcessadorFolhaPagamento(
        IRepositorioPagamento repositorio,
        IServicoMensageria mensageria)
    {
        _repositorio = repositorio;
        _mensageria = mensageria;
    }

    public async Task ProcessarAsync(string funcionario, string destinatario, decimal salarioBruto, decimal descontos)
    {
        if (salarioBruto <= 0)
            throw new ArgumentException("Salário bruto deve ser maior que zero.", nameof(salarioBruto));

        var salarioLiquido = salarioBruto - descontos;

        await _repositorio.SalvarPagamentoAsync(funcionario, salarioLiquido);
        await _mensageria.NotificarPagamentoAsync(destinatario, salarioLiquido);
    }
}