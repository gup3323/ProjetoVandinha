using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vandinha.Context
{
    public class VendinhaDbContext : DbContext
    {
        private string connectionString;
        public VendinhaDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Divida> Dividas => Set<Divida>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var clienteEntity = modelBuilder.Entity<Cliente>();
            clienteEntity.ToTable("clientes");
            clienteEntity.HasKey(c => c.Cpf);
            clienteEntity.Property(c => c.Cpf).HasColumnName("cpf_cliente");
            clienteEntity.Property(c => c.NomeCompleto).HasColumnName("nome_cliente");
            clienteEntity.Property(c => c.Email).HasColumnName("email_cliente");
            clienteEntity.Property(c => c.DataNascimento).HasColumnName("data_nascimento_cliente");

            var dividaEntity = modelBuilder.Entity<Divida>();
            dividaEntity.ToTable("dividas");
            dividaEntity.HasKey(d => d.id_divida);
            dividaEntity.Property(d => d.CpfCliente).HasColumnName("cliente_id");
            dividaEntity.Property(d => d.Valor).HasColumnName("valor_divida");
            dividaEntity.Property(d => d.Situacao).HasColumnName("situacao_divida");
            dividaEntity.Property(d => d.DataCriacao).HasColumnName("data_registro");
            dividaEntity.Property(d => d.DataPagamento).HasColumnName("data_pagamento");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
