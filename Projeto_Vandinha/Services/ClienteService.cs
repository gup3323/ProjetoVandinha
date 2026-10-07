```csharp
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto_Vandinha.Services
{
    public class ClienteService
    {
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
            string email)
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

            if (!Validar(cliente))
            {
                Console.WriteLine("Dados do cliente inválidos.");
                return false;
            }

            // Banco de dados para adicionar ainda

            Console.WriteLine("Cliente criado com sucesso!");
            return true;
        }
    }
}