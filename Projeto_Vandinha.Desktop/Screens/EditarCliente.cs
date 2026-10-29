using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class EditarCliente : Form
    {
        private string cpfOriginal;
        private readonly ClienteService service;
        public EditarCliente(string cpfCliente)
        {
            InitializeComponent();
            service = new ClienteService();
            cpfOriginal = cpfCliente;
            _ = CarregarDadosDoBancoAsync(cpfOriginal);
        }
        private async Task CarregarDadosDoBancoAsync(string cpf)
        {
            var cliente = await service.BuscarClientePorCpf(cpf);

            if (cliente != null)
            {
                cpfEditar.Text = cliente.Cpf;
                nomeCompletoEditar.Text = cliente.NomeCompleto;
                emailEditar.Text = cliente.Email;
                dataNascimentoEditar.Value = cliente.DataNascimento;
            }
            else
            {
                MessageBox.Show("Cliente não encontrado no banco de dados.");
                this.Close();
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var clienteAtualizado = new Cliente
            {
                Cpf = cpfEditar.Text,
                NomeCompleto = nomeCompletoEditar.Text,
                Email = emailEditar.Text,
                DataNascimento = dataNascimentoEditar.Value
            };
            bool sucesso = await service.AtualizarCliente(cpfOriginal, clienteAtualizado);

            if (sucesso)
            {
                MessageBox.Show("Cliente atualizado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha ao atualizar o cliente.");
            }
        }
    }
}
