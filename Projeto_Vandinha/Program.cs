using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Projeto_Vandinha.Models;
using Projeto_Vandinha.Projeto_Vandinha.Services;
using Projeto_Vandinha.Services;

var service = new ClienteService();
Console.WriteLine("Digite o cpf: ");
var Cpf = Console.ReadLine();
Console.WriteLine("Digite o nome: ");
var NomeCompleto = Console.ReadLine();
Console.WriteLine("Digite o email: ");
var Email = Console.ReadLine();
Console.WriteLine("Digite a data de nascimento: ");
var DataNascimento = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Digite o valor da divida: ");
var ValorDivida = int.Parse(Console.ReadLine());
Console.WriteLine("Digite a data de Pagamento: ");
var DataPagamento = DateTime.Parse(Console.ReadLine());

var dividaTeste = new Divida
{
    Cpf = Cpf,
    Valor = ValorDivida,
    Situacao = false,
    DataCriacao = DateTime.Now,
    DataPagamento = DataPagamento
};

var divida = new DividaService();

var criarDivida = divida.CriarDivida(
    dividaTeste.Cpf = Cpf,
    dividaTeste.Valor,
    dividaTeste.Situacao,
    dividaTeste.DataCriacao,
    dividaTeste.DataPagamento.Value,
    NomeCompleto = NomeCompleto,
    DataNascimento = DataNascimento,
    Email = Email
);


var clienteTeste = new Cliente
{
    Cpf = Cpf,
    NomeCompleto = NomeCompleto,
    DataNascimento = DataNascimento,
    Email = Email
};

var clienteCriado = service.CriarCliente(Cpf, NomeCompleto, DataNascimento, Email);

if (clienteCriado)
{
    Console.WriteLine("Cliente criado com sucesso!");
}
else
{
    Console.WriteLine("Falha ao criar cliente.");
}