using Npgsql;
using NpgsqlTypes;
using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;


namespace Projeto_Vandinha.Projeto_Vandinha.Services
{
    internal class DividaService
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=VendinhaPagamentos;Username=postgres;Password=123;TrustServerCertificate=True;";

        public List<Divida> ConsultaDivida()
        {
            var resultado = new List<Divida>();

            using var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();

            var sql = "SELECT valor_divida, situacao_divida, data_registro, data_pagamento FROM dividas";

            using var comando = new NpgsqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var divida = new Divida
                {
                    Valor = leitor["valor_divida"] != DBNull.Value ? Convert.ToInt32(leitor["valor_divida"]) : 0,
                    Situacao = leitor["situacao_divida"] != DBNull.Value && Convert.ToBoolean(leitor["situacao_divida"]),
                    DataCriacao = leitor["data_registro"] != DBNull.Value ? Convert.ToDateTime(leitor["data_registro"]) : default,
                    DataPagamento = leitor["data_pagamento"] != DBNull.Value ? Convert.ToDateTime(leitor["data_pagamento"]) : (DateTime?)null
                };
                resultado.Add(divida);
            }

            return resultado;
        }

        public bool CriarDivida(string cpf, int valor, bool situacao, DateTime dataCriacao, DateTime? dataPagamento, string nomeCompleto, DateTime dataNascimento, string email)
        {
            string clienteIdStr = ValidaDivida(cpf, valor, situacao, dataCriacao, dataPagamento, nomeCompleto, dataNascimento, email);

            if (clienteIdStr == "0")
            {
                Console.WriteLine("Não foi possível criar a dívida para o cliente. Verifique se ele é cadastrado.");
                return false;
            }

            if (!int.TryParse(clienteIdStr, out int clienteId))
            {
                Console.WriteLine("Erro ao converter o ID do cliente.");
                return false;
            }

            using var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();

            var sqlInsertDivida = @"INSERT INTO dividas (cliente_id, valor_divida, situacao_divida, data_registro, data_pagamento) 
                                    VALUES (@ClienteId, @Valor, @Situacao, @DataCriacao, @DataPagamento)";

            using var comandoInsertDivida = new NpgsqlCommand(sqlInsertDivida, conexao);
            comandoInsertDivida.Parameters.AddWithValue("@ClienteId", clienteId);
            comandoInsertDivida.Parameters.AddWithValue("@Valor", valor);
            comandoInsertDivida.Parameters.AddWithValue("@Situacao", situacao);
            comandoInsertDivida.Parameters.AddWithValue("@DataCriacao", dataCriacao);
            comandoInsertDivida.Parameters.AddWithValue("@DataPagamento", (object)dataPagamento ?? DBNull.Value);

            int linhasAfetadas = comandoInsertDivida.ExecuteNonQuery();

            Console.WriteLine("Dívida criada com sucesso.");
            return linhasAfetadas > 0;
        }

        public string ValidaDivida(string cpf, int valor, bool situacao, DateTime dataCriacao, DateTime? dataPagamento, string nomeCompleto, DateTime dataNascimento, string email)
        {
            // Proteção contra CPF nulo ou vazio
            if (string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("O CPF não pode ser nulo ou vazio.");
                return "0";
            }

            if (valor <= 0)
            {
                Console.WriteLine("O valor da dívida não pode ser negativo ou zero.");
                return "0";
            }

            using var conexao = new NpgsqlConnection(connectionString);
            conexao.Open();

            var sqlExisteCpf = "SELECT id_cliente FROM clientes WHERE CPF_cliente = @Cpf";
            using var comandoExisteCpf = new NpgsqlCommand(sqlExisteCpf, conexao);

            // CORREÇÃO: Cast explícito para object e tratamento seguro com DBNull.Value
            comandoExisteCpf.Parameters.AddWithValue("@Cpf", (object)cpf ?? DBNull.Value);

            object resultadoObj = comandoExisteCpf.ExecuteScalar();

            if (resultadoObj != null && resultadoObj != DBNull.Value)
            {
                Console.WriteLine("Cliente encontrado. Dívida validada.");
                return resultadoObj.ToString()!; // Retorna o ID do cliente encontrado
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return "0";
            }
        }


    }
}