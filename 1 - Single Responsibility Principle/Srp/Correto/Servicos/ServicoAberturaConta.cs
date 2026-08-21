namespace Srp.Correto.Servicos;

using Srp.Correto.Abstracoes;
using Srp.Correto.ObjetosDeValor;

public class ServicoAberturaConta
{
    private readonly IServicoAnaliseFraude _servicoAnaliseFraude;
    private readonly IRepositorioConta _repositorioConta;
    private readonly IServicoNotificacao _servicoNotificacao;

    // A única responsabilidade desta classe é orquestrar o processo de abertura de conta
    public ServicoAberturaConta(
        IServicoAnaliseFraude servicoAnaliseFraude,
        IRepositorioConta repositorioConta,
        IServicoNotificacao servicoNotificacao)
    {
        _servicoAnaliseFraude = servicoAnaliseFraude;
        _repositorioConta = repositorioConta;
        _servicoNotificacao = servicoNotificacao;
    }

    public async Task AbrirContaAsync(string nome, string email, string cpfBruto, decimal depositoInicial)
    {
        var cpf = new Cpf(cpfBruto);

        var aprovado = await _servicoAnaliseFraude.EstaAprovadoAsync(cpf, depositoInicial);
        if (!aprovado)
            throw new InvalidOperationException("Solicitação reprovada na análise de fraude e crédito.");

        await _repositorioConta.SalvarContaAsync(nome, email, cpf, depositoInicial);
        await _servicoNotificacao.EnviarEmailBoasVindasAsync(email, nome);
    }
}