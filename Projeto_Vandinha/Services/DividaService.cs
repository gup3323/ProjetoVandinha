using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Projeto_Vandinha.Context;
using Projeto_Vandinha.Models;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Vandinha.Services
{
    public class DividaService
    {
        
        private const string connectionString = "Host=localhost;Port=5432;Database=VendinhaPagamentos;Username=postgres;Password=123;TrustServerCertificate=True;";

        public DividaService() : this(new VendinhaDbContext(connectionString)) {}
        private VendinhaDbContext context;

        public DividaService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public int CriarDivida(string cpf, decimal valor, DateTime dataPagamento)
        {
            var retorno = 0;
            var validacpf = new ClienteService();
            if (validacpf.ValidarCPF(cpf))
            {
                retorno = 1;
                return retorno;
            }
            var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();
            var sqlExisteCpf = """SELECT COUNT(*) FROM clientes WHERE CPF_cliente = @Cpf""";
            var comandoExisteCpf = new NpgsqlCommand(sqlExisteCpf, conexao);
            comandoExisteCpf.Parameters.Add("Cpf", NpgsqlDbType.Varchar).Value = cpf;

            var sqlDividaAberta = """SELECT COUNT(*) FROM dividas WHERE cliente_id = @Cpf AND situacao_divida = 'PENDENTE'""";
            var comandoDividaAberta = new NpgsqlCommand(sqlDividaAberta, conexao);
            comandoDividaAberta.Parameters.Add("Cpf", NpgsqlDbType.Varchar).Value = cpf;
            var resultadoDividaAberta = (long)comandoDividaAberta.ExecuteScalar();
            if (resultadoDividaAberta > 0)
            {
                Console.WriteLine("Cliente já possui uma dívida em aberto.");
                retorno = 2;
            }
            else
            {
                var divida = new Divida
                {

                    CpfCliente = cpf,
                    Valor = (decimal)valor,
                    Situacao = "PENDENTE".ToUpper(),
                    DataCriacao = DateTime.Now,
                    DataPagamento = dataPagamento
                };

                var sqlInsertDivida = """INSERT INTO dividas (cliente_id, valor_divida, situacao_divida, data_registro, data_pagamento) VALUES (@Cpf, @Valor, 'PENDENTE', @DataCriacao, @DataPagamento)""";
                var comandoInsertDivida = new NpgsqlCommand(sqlInsertDivida, conexao);
                //comandoInsertDivida.Parameters.Add("id", NpgsqlDbType.Integer).Value = 0;
                comandoInsertDivida.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = divida.CpfCliente;
                comandoInsertDivida.Parameters.Add("Valor", NpgsqlDbType.Numeric).Value = divida.Valor;
                comandoInsertDivida.Parameters.Add("DataCriacao", NpgsqlDbType.Date).Value = divida.DataCriacao;
                comandoInsertDivida.Parameters.Add("DataPagamento", NpgsqlDbType.Date).Value = divida.DataPagamento;
                comandoInsertDivida.ExecuteNonQuery();
                retorno = 3;
            }
            return retorno;
        }
        public async Task<List<Divida>> ListarDivida(int paginaAtual)
        {
            if (paginaAtual < 1) paginaAtual = 1;
            
            return await context.Dividas.OrderBy(d => d.DataCriacao).Skip((paginaAtual - 1) * 10).Take(10).AsNoTracking().ToListAsync();    
        }

        public async Task<int> ObterTotalPaginas()
        {
            int totalDividas = await context.Dividas.CountAsync();
            return (int)Math.Ceiling((double)totalDividas / 10);
        }

        public async Task<List<Divida>> BuscarDividas(string cpf)
        {
            return await context.Dividas.Where(d => d.CpfCliente == cpf).AsNoTracking().ToListAsync();
        }

        public async Task<Divida> BuscarDividaPorCpf(string cpf)
        {
            return await context.Dividas.FirstOrDefaultAsync(d => d.CpfCliente == cpf);
        }

        public async Task<bool> AtualizarSituacaoDivida(string cpf, Divida dividaAtualizada)
        {
            var divida = await context.Dividas.FirstOrDefaultAsync(d => d.CpfCliente == cpf);
            var situacao = dividaAtualizada.Situacao.ToUpper();
            DateTime dataPagou = dividaAtualizada.DataPagamento;
            if (divida == null)
            {
                return false;
            }
            divida.Situacao = divida.Situacao = "PAGO".ToUpper();
            if (dataPagou != null)
            {
                divida.DataPagamento = dataPagou;
            }
            else
            {
                var dataOriginal = divida.DataPagamento;
                divida.Situacao = dividaAtualizada.Situacao?.Trim().ToUpper();

                divida.DataPagamento = dividaAtualizada.DataPagamento;
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
