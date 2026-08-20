using Ocp.Correto.Abstracoes;
using Ocp.Correto.Estrategias;
using Ocp.Correto.Modelos;
using Ocp.Correto.Servicos;
using Incorreto = Ocp.Incorreto;

Console.WriteLine("=== Princípio Aberto/Fechado (OCP - Open/Closed Principle) ===\n");

// 1. Executando o modelo incorreto (baseado em if/else engessado)
Console.WriteLine("--- 1. Executando Modo Incorreto (Violando OCP) ---");
var processadorIncorreto = new Incorreto.ProcessadorPagamento();
processadorIncorreto.Processar(new Incorreto.Pedido { Valor = 150.00m, Tipo = Incorreto.TipoPagamento.Pix });
processadorIncorreto.Processar(new Incorreto.Pedido { Valor = 320.50m, Tipo = Incorreto.TipoPagamento.CartaoCredito });

Console.WriteLine("\n------------------------------------------------------------\n");

// 2. Executando o modelo correto (Padrão Strategy + Polimorfismo)
Console.WriteLine("--- 2. Executando Modo Correto (OCP Respeitado) ---");

// Coleção de estratégias disponíveis registradas no sistema
var estrategias = new List<IEstrategiaPagamento>
{
    new PagamentoPix(),
    new PagamentoCartaoCredito(),
    new PagamentoBoleto(),
    new PagamentoCripto() // Nova funcionalidade estendida sem alterar o processador
};

var processadorCorreto = new ProcessadorPagamento(estrategias);

var pedidos = new List<Pedido>
{
    new(Guid.NewGuid(), 250.00m, TipoPagamento.Pix),
    new(Guid.NewGuid(), 1200.00m, TipoPagamento.CartaoCredito),
    new(Guid.NewGuid(), 89.90m, TipoPagamento.Boleto),
    new(Guid.NewGuid(), 5000.00m, TipoPagamento.Cripto)
};

foreach (var pedido in pedidos)
{
    var resultado = await processadorCorreto.ProcessarAsync(pedido);
    Console.WriteLine($"-> Status: {(resultado.Sucesso ? "Sucesso" : "Falha")} | Detalhe: {resultado.Mensagem}\n");
}

var pedidoBoleto = new Pedido(Guid.NewGuid(), 150.00m, TipoPagamento.Boleto);

var resultadoBoleto = await processadorCorreto.ProcessarAsync(pedidoBoleto);

Console.WriteLine($"-> Status: {(resultadoBoleto.Sucesso ? "Sucesso" : "Falha")} | Detalhe: {resultadoBoleto.Mensagem}\n");

Console.WriteLine("Processamento de todas as estratégias concluído!");