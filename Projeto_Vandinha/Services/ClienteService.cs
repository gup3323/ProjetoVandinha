
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;
using Projeto_Vandinha.Context;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto_Vandinha.Services
{
    public class ClienteService
    {
        private const string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=051059;TrustServerCertificate=True;";

        public ClienteService() : this(new VendinhaDbContext(connectionString)) {}
        private VendinhaDbContext context;

        public ClienteService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (!long.TryParse(cpf, out _))
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(cpf[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += numeros[i] * (10 - i);
            }

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if (primeiroDigito != numeros[9])
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += numeros[i] * (11 - i);
            }

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            if (segundoDigito != numeros[10])
                return false;

            return true;
        }

        public bool Validar(Cliente cliente)
        {
            var context = new ValidationContext(cliente);
            var erros = new List<ValidationResult>();

            return Validator.TryValidateObject(
                cliente,
                context,
                erros,
                true
            );
        }
        private bool cpfValido = false;

        public async Task<int> CriarCliente(Cliente cliente)
        {
            if (!ValidarCPF(cliente.Cpf))
            {
                Console.WriteLine("CPF inválido.");
                return 1;
            }
            else
            {
                cpfValido = true;
                if (!Validar(cliente))
                {
                    Console.WriteLine("Algo deu errado.");
                    return 2;
                }
                else
                {
                    var cpfBanco = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                    if (cpfBanco != null)
                    {
                        Console.WriteLine("Cliente com este CPF já existe.");
                        return 3;
                    }
                    else
                    {
                        context.Clientes.Add(cliente);
                        await context.SaveChangesAsync();
                        return 0;
                    }
                }
            }
        }

        public async Task<List<Cliente>> ListarClientes(int paginaAtual)
        {

            if (paginaAtual < 1) paginaAtual = 1;
            return await context.Clientes.OrderBy(c => c.NomeCompleto).Skip((paginaAtual - 1) * 10).Take(10).AsNoTracking().ToListAsync();
        }

        public async Task<List<Cliente>> BuscarClientes(string pesquisa)
        {
            var resultados = context.Clientes.Where(c => c.Cpf.Contains(pesquisa) ||
            c.NomeCompleto.Contains(pesquisa) ||
            c.Email.Contains(pesquisa)).OrderBy(c => c.NomeCompleto);
            return resultados.ToList();
        }
        public async Task<Cliente?> BuscarClientePorCpf(string cpf)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            return cliente;
        }
        public async Task<bool> AtualizarCliente(string cpf, Cliente clienteAtualizado)
        {
            var clienteExistente = await BuscarClientePorCpf(cpf);
            if (clienteExistente == null)
            {
                return false;
            }
            clienteExistente.NomeCompleto = clienteAtualizado.NomeCompleto;
            clienteExistente.DataNascimento = DateTime.SpecifyKind(clienteAtualizado.DataNascimento, DateTimeKind.Utc);
            clienteExistente.Email = clienteAtualizado.Email;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarCliente(string cpf)
        {
            var clienteExistente = await BuscarClientePorCpf(cpf);
            if (clienteExistente == null)
            {
                return false;
            }
            context.Clientes.Remove(clienteExistente);
            await context.SaveChangesAsync();
            return true;
        }

        public bool CriarDivida(string cpf, decimal valor)
        {
            var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();
            var sqlExisteCpf = """SELECT COUNT(*) FROM clientes WHERE cpf_cliente = @Cpf""";
            var comandoExisteCpf = new NpgsqlCommand(sqlExisteCpf, conexao);
            comandoExisteCpf.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = cpf;
            var resultadoExisteCpf = (long)comandoExisteCpf.ExecuteScalar();
            if (resultadoExisteCpf == 0)
            {
                Console.WriteLine("Cliente com este CPF não existe.");
                return false;
            }
            var sqlDividaAberta = """SELECT COUNT(*) FROM dividas WHERE cpf_cliente = @Cpf AND situacao_divida = false""";
            var comandoDividaAberta = new NpgsqlCommand(sqlDividaAberta, conexao);
            comandoDividaAberta.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = cpf;
            var resultadoDividaAberta = (long)comandoDividaAberta.ExecuteScalar();
            if (resultadoDividaAberta > 0)
            {
                Console.WriteLine("Cliente já possui uma dívida em aberto.");
                return false;
            }
            else
            {
                var sqlInsertDivida = """INSERT INTO dividas (cpf_cliente, valor_divida, situacao_divida, data_criacao_divida) VALUES (@Cpf, @Valor, false, @DataCriacao)""";
                var comandoInsertDivida = new NpgsqlCommand(sqlInsertDivida, conexao);
                comandoInsertDivida.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = cpf;
                comandoInsertDivida.Parameters.Add("Valor", NpgsqlDbType.Numeric).Value = valor;
                comandoInsertDivida.Parameters.Add("DataCriacao", NpgsqlDbType.Timestamp).Value = DateTime.Now;
                comandoInsertDivida.ExecuteNonQuery();
                return true;
            }
        }
    }
}