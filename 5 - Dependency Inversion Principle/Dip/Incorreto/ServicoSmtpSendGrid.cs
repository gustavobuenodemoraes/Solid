namespace Dip.Incorreto;

public class ServicoSmtpSendGrid
{
    public void EnviarComprovante(string email, decimal valor)
    {
        Console.WriteLine($"[SendGrid API] Enviando e-mail para {email} com holerite no valor de R$ {valor:N2}.");
    }
}