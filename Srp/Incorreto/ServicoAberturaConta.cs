namespace Srp.Incorreto;

/// <summary>
/// VIOLAÇÃO DO SRP:
/// Esta classe tem múltiplos motivos para mudar:
/// 1. Alteração na regra de validação de CPF.
/// 2. Alteração na integração com a base de dados (Oracle/SQL Server).
/// 3. Mudança nas regras de análise de crédito e fraude.
/// 4. Mudança no provedor ou formato do e-mail de notificação.
/// </summary>
public class ServicoAberturaConta
{
    public void AbrirConta(string nome, string email, string cpfBruto, decimal depositoInicial)
    {
        // 1. Validação de formato de CPF (Regra de Documento)
        if (string.IsNullOrWhiteSpace(cpfBruto) || cpfBruto.Length != 11)
            throw new ArgumentException("CPF inválido. Deve conter 11 dígitos.");

        // 2. Consulta de risco e antifraude (Regra de Segurança/Crédito)
        Console.WriteLine($"[Antifraude] Consultando histórico de crédito do CPF {cpfBruto} no bureau...");
        bool aprovado = depositoInicial > 0;
        if (!aprovado)
            throw new InvalidOperationException("Reprovado na política interna de crédito.");

        // 3. Persistência no Banco de Dados (Infraestrutura / Acesso a Dados)
        Console.WriteLine($"[Banco de Dados] INSERT INTO Contas (Nome, Email, Cpf, Saldo) VALUES ('{nome}', '{email}', '{cpfBruto}', {depositoInicial});");

        // 4. Envio de Notificação ao Cliente (Comunicação / Notificação)
        Console.WriteLine($"[SMTP] Enviando e-mail de boas-vindas para {email} via servidor de e-mail...");
    }
}