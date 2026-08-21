namespace Dip.Incorreto;

/// <summary>
/// VIOLAÇÃO DO DIP:
/// 1. Módulo de alto nível (Regra de Folha) depende diretamente de detalhes de baixo nível (SQL Server e SendGrid).
/// 2. As dependências são instanciadas na "unha" com 'new', impedindo testes de unidade com mocks.
/// 3. Se a empresa migrar para Oracle ou AWS SQS, esta classe de negócio precisará ser reescrita.
/// </summary>
public class ProcessadorFolhaPagamento
{
    private readonly RepositorioSqlServer _repositorioSql;
    private readonly ServicoSmtpSendGrid _servicoEmail;

    public ProcessadorFolhaPagamento()
    {
        // Alto acoplamento: amarrado a implementações concretas
        _repositorioSql = new RepositorioSqlServer();
        _servicoEmail = new ServicoSmtpSendGrid();
    }

    public void Processar(string funcionario, string email, decimal salarioBruto, decimal descontos)
    {
        var salarioLiquido = salarioBruto - descontos;

        _repositorioSql.SalvarPagamento(funcionario, salarioLiquido);
        _servicoEmail.EnviarComprovante(email, salarioLiquido);
    }
}