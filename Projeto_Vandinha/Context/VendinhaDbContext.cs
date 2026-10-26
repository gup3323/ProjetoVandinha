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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var clienteEntity = modelBuilder.Entity<Cliente>();
            clienteEntity.ToTable("clientes");
            clienteEntity.HasKey(c => c.Cpf);
            clienteEntity.Property(c => c.Cpf).HasColumnName("cpf_cliente");
            clienteEntity.Property(c => c.NomeCompleto).HasColumnName("nome_cliente");
            clienteEntity.Property(c => c.Email).HasColumnName("email_cliente");
            clienteEntity.Property(c => c.DataNascimento).HasColumnName("data_nascimento_cliente");
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
