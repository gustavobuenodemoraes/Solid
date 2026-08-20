namespace Srp.Correto.ObjetosDeValor;

public readonly record struct Cpf
{
    public string Valor { get; }

    public Cpf(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor) || valor.Length != 11)
            throw new ArgumentException("CPF deve conter exatamente 11 dígitos.", nameof(valor));

        Valor = valor;
    }
}