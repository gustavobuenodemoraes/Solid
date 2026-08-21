namespace Isp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO ISP:
/// Como a interface IContratoBancarioGordo obriga a implementação de todos os métodos,
/// a classe ClientePessoaFisica tenta implementar tudo, mesmo que algumas operações
/// pertençam a dispositivos físicos (como impressão térmica de papel).
/// </summary>
public class ClientePessoaFisica : IContratoBancarioGordo
{
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public ClientePessoaFisica(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"[Cliente PF] Pagamento de R$ {valor:N2} autorizado via aplicativo por {Nome}.");
    }

    public void ValidarBiometriaFacial(byte[] foto)
    {
        Console.WriteLine($"[Cliente PF] Biometria facial de {Nome} enviada via câmera do smartphone.");
    }

    public void SolicitarEmprestimo(decimal valor)
    {
        Console.WriteLine($"[Cliente PF] Proposta de crédito pessoal de R$ {valor:N2} enviada para análise.");
    }

    public void ImprimirComprovantePapel()
    {
        // Um cliente usando aplicativo mobile não imprime papel termicamente!
        throw new NotImplementedException("O aplicativo do cliente não possui impressora física.");
    }
}