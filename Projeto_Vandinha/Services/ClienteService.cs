using Microsoft.EntityFrameworkCore;
using Projeto_Vandinha.Context;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Vandinha.Services
{
    public class ClienteService
    {
        private const string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=051059;TrustServerCertificate=True;";
        private readonly VendinhaDbContext context;

        public ClienteService() : this(new VendinhaDbContext(connectionString)) { }

        public ClienteService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public static string NormalizarCpf(string? cpf)
        {
            return cpf?.Trim().Replace(".", "").Replace("-", "") ?? string.Empty;
        }

        public bool ValidarCPF(string cpf)
        {
            cpf = NormalizarCpf(cpf);

            if (cpf.Length != 11 || !cpf.All(char.IsAsciiDigit))
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] numeros = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += numeros[i] * (10 - i);

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;
            if (primeiroDigito != numeros[9])
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += numeros[i] * (11 - i);

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;
            return segundoDigito == numeros[10];
        }

        public bool Validar(Cliente cliente)
        {
            var validationContext = new ValidationContext(cliente);
            var erros = new List<ValidationResult>();

            bool valido = Validator.TryValidateObject(cliente, validationContext, erros, true);
            if (!valido) return false;

            if (cliente.Idade < 15 || cliente.Idade > 100)
                return false;

            return true;
        }

        public async Task<int> CriarCliente(Cliente cliente)
        {
            cliente.Cpf = NormalizarCpf(cliente.Cpf);
            cliente.DataNascimento = cliente.DataNascimento.Date;

            if (!ValidarCPF(cliente.Cpf))
                return 1; // CPF inválido

            if (!Validar(cliente))
                return 2; // Dados inválidos

            var cpfBanco = await context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);

            if (cpfBanco != null)
                return 3; // CPF já cadastrado

            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return 0; // Sucesso
        }

        public async Task<List<Cliente>> ListarClientes(int paginaAtual)
        {
            if (paginaAtual < 1) paginaAtual = 1;

            return await context.Clientes
                .Include(c => c.Dividas)
                .OrderByDescending(c => c.Dividas
                    .Where(d => d.Situacao == "PENDENTE")
                    .Sum(d => (decimal?)d.Valor) ?? 0m)
                .ThenBy(c => c.NomeCompleto)
                .Skip((paginaAtual - 1) * 10)
                .Take(10)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Cliente>> BuscarClientes(string pesquisa)
        {
            string termo = pesquisa.Trim().ToLower();
            string termoCpf = NormalizarCpf(pesquisa);

            return await context.Clientes
                .Include(c => c.Dividas)
                .Where(c => c.NomeCompleto.ToLower().Contains(termo) ||
                            (!string.IsNullOrEmpty(termoCpf) && c.Cpf.Contains(termoCpf)))
                .OrderByDescending(c => c.Dividas
                    .Where(d => d.Situacao == "PENDENTE")
                    .Sum(d => (decimal?)d.Valor) ?? 0m)
                .ThenBy(c => c.NomeCompleto)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> BuscarClientePorCpf(string cpf)
        {
            string cpfNormalizado = NormalizarCpf(cpf);
            return await context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefaultAsync(c => c.Cpf == cpfNormalizado);
        }

        public async Task<bool> AtualizarCliente(string cpf, Cliente clienteAtualizado)
        {
            string cpfNormalizado = NormalizarCpf(cpf);
            var clienteExistente = await context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpfNormalizado);
            if (clienteExistente == null)
                return false;

            clienteExistente.NomeCompleto = clienteAtualizado.NomeCompleto;
            clienteExistente.DataNascimento = clienteAtualizado.DataNascimento.Date;
            clienteExistente.Email = clienteAtualizado.Email;

            if (!Validar(clienteExistente))
                return false;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarCliente(string cpf)
        {
            string cpfNormalizado = NormalizarCpf(cpf);
            var clienteExistente = await context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpfNormalizado);
            if (clienteExistente == null)
                return false;

            context.Clientes.Remove(clienteExistente);
            await context.SaveChangesAsync();
            return true;
        }
    }
}