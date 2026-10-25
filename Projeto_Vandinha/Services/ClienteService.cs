
using Npgsql;
using NpgsqlTypes;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto_Vandinha.Services
{
    public class ClienteService
    {
        private string connectionString = "Host=localhost;Port=5432;Database=VendinhaPagamentos;Username=postgres;Password=051059;TrustServerCertificate=True;";


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

        public bool CriarCliente(
            string cpf,
            string nomeCompleto,
            DateTime dataNascimento,
            string email
            )
        {
            var cliente = new Cliente
            {
                Cpf = cpf,
                NomeCompleto = nomeCompleto,
                DataNascimento = dataNascimento,
                Email = email
            };

            if (!ValidarCPF(cpf))
            {
                Console.WriteLine("CPF inválido.");
                return false;
            }

            if (Validar(cliente))
            {
                Console.WriteLine("Dados do cliente inválidos.");
                Console.WriteLine("teste");
                return false;
            }

            var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();
            var sqlExisteCpf = """SELECT COUNT(*) FROM clientes WHERE cpf_cliente = @Cpf""";
            var comandoExisteCpf = new NpgsqlCommand(sqlExisteCpf, conexao);
            comandoExisteCpf.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = cliente.Cpf;
            var resultadoExisteCpf = (long)comandoExisteCpf.ExecuteScalar();

            if (resultadoExisteCpf > 0)
            {
                Console.WriteLine("Cliente com este CPF já existe.");
                return false;
            }
            else
            {
                var sqlInsert = """INSERT INTO clientes (cpf_cliente, nome_cliente, email_cliente, data_nascimento_cliente) VALUES (@Cpf, @NomeCompleto, @Email, @DataNascimento)""";
                var comando = new NpgsqlCommand(sqlInsert, conexao);
                comando.Parameters.Add("Cpf", NpgsqlDbType.Text).Value = cliente.Cpf;
                comando.Parameters.Add("NomeCompleto", NpgsqlDbType.Text).Value = cliente.NomeCompleto;
                comando.Parameters.Add("Email", NpgsqlDbType.Text).Value = cliente.Email;
                comando.Parameters.Add("DataNascimento", NpgsqlDbType.Date).Value = cliente.DataNascimento;
                comando.ExecuteNonQuery();
                return true;
            }
            
        }

        public List<Cliente> ListarClientes()
        {
            var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();
            var sql = """SELECT * FROM Clientes""";
            var comando = new NpgsqlCommand(sql, conexao);
            var leitor = comando.ExecuteReader();
            var resultado = new List<Cliente>();
            while (leitor.Read())
            {
                var aluno = new Cliente
                {
                    Cpf = leitor.GetString(0),
                    NomeCompleto = leitor.GetString(1),
                    Email = leitor.GetString(2),
                    DataNascimento = leitor.GetDateTime(3)
                };
                resultado.Add(aluno);
            }
            return resultado;
        }


        public bool CriarDivida(bool situacao1, string cpf, bool situacao, decimal valor)
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