using Microsoft.EntityFrameworkCore;
using Projeto_Vandinha.Context;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Vandinha.Services
{
    public class DividaService
    {
        private const string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=051059;TrustServerCertificate=True;";
        private readonly VendinhaDbContext context;

        public DividaService() : this(new VendinhaDbContext(connectionString)) { }

        public DividaService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CriarDivida(string cpf, decimal valor, DateTime? dataPagamento = null)
        {
            string cpfNormalizado = ClienteService.NormalizarCpf(cpf);
            var clienteService = new ClienteService();

            if (!clienteService.ValidarCPF(cpfNormalizado))
                return 1;

            if (valor <= 0)
                return 3;

            bool clienteExiste = await context.Clientes.AnyAsync(c => c.Cpf == cpfNormalizado);
            if (!clienteExiste)
                return 1;

            bool possuiDividaAberta = await context.Dividas
                .AnyAsync(d => d.CpfCliente == cpfNormalizado && d.Situacao == "PENDENTE");

            if (possuiDividaAberta)
                return 2;

            var divida = new Divida
            {
                CpfCliente = cpfNormalizado,
                Valor = valor,
                Situacao = "PENDENTE",
                DataCriacao = DateTime.Now,
                DataPagamento = dataPagamento
            };

            context.Dividas.Add(divida);
            await context.SaveChangesAsync();
            return 0;
        }

        public async Task<List<Divida>> ListarDivida(int paginaAtual)
        {
            if (paginaAtual < 1) paginaAtual = 1;

            return await context.Dividas
                .OrderByDescending(d => d.Situacao == "PENDENTE")
                .ThenByDescending(d => d.DataCriacao)
                .Skip((paginaAtual - 1) * 10)
                .Take(10)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Divida>> BuscarDividas(string pesquisa)
        {
            string cpfNormalizado = ClienteService.NormalizarCpf(pesquisa);

            return await context.Dividas
                .Where(d => d.CpfCliente.Contains(cpfNormalizado))
                .OrderByDescending(d => d.Situacao == "PENDENTE")
                .ThenByDescending(d => d.DataCriacao)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Divida?> BuscarDividaPorId(int idDivida)
        {
            return await context.Dividas.FirstOrDefaultAsync(d => d.id_divida == idDivida);
        }

        public async Task<Divida?> BuscarDividaPorCpf(string cpf)
        {
            string cpfNormalizado = ClienteService.NormalizarCpf(cpf);

            return await context.Dividas
                .OrderByDescending(d => d.Situacao == "PENDENTE")
                .ThenByDescending(d => d.DataCriacao)
                .FirstOrDefaultAsync(d => d.CpfCliente == cpfNormalizado);
        }

        public async Task<bool> AtualizarSituacaoDivida(int idDivida, Divida dividaAtualizada)
        {
            var divida = await context.Dividas.FirstOrDefaultAsync(d => d.id_divida == idDivida);
            if (divida == null)
                return false;

            string novaSituacao = dividaAtualizada.Situacao?.Trim().ToUpperInvariant() ?? "PENDENTE";
            divida.Situacao = novaSituacao;

            if (novaSituacao == "PAGO")
            {
                divida.DataPagamento = dividaAtualizada.DataPagamento ?? DateTime.Now;
            }
            else
            {
                divida.DataPagamento = null;
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}