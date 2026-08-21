namespace Dip.Incorreto;

public class RepositorioSqlServer
{
    public void SalvarPagamento(string funcionario, decimal salarioLiquido)
    {
        Console.WriteLine($"[SQL Server] INSERT INTO Folha (Funcionario, Valor) VALUES ('{funcionario}', {salarioLiquido});");
    }
}