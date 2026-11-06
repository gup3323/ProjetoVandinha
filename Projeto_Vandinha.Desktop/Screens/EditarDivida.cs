using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Projeto_Vandinha.Services;
using Projeto_Vandinha.Models;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class EditarDivida : Form
    {
        private string cpfOriginal;
        private readonly DividaService service;
        public EditarDivida(string cpfOriginal)
        {
            InitializeComponent();
            service = new DividaService();
            this.cpfOriginal = cpfOriginal;
            _ = CarregarDadosDoBancoAsync(this.cpfOriginal);
        }

        private async Task CarregarDadosDoBancoAsync(string cpf)
        {
            var divida = await service.BuscarDividaPorCpf(cpf);
            if (divida != null)
            {
                situacaoEditar.Text = divida.Situacao == "PAGO".ToUpper() ? "PAGO".ToUpper() : "PENDENTE".ToUpper();
                data_pagamento.Value = divida.DataPagamento;
            }
            else
            {
                MessageBox.Show("Dívida não encontrada no banco de dados.");
                this.Close();
            }
        }

        private async void EditarDivida_Load(object sender, EventArgs e)
        {
            var service = new DividaService();
            var divida = await service.BuscarDividaPorCpf(cpfOriginal);
            if (divida != null)
            {
                situacaoEditar.Text = divida.Situacao == "PAGO".ToUpper() ? "PAGO".ToUpper() : "PENDENTE".ToUpper();
                data_pagamento.Value=  divida.DataPagamento;
            }
            else
            {
                MessageBox.Show("Dívida não encontrada no banco de dados.");
                this.Close();
            }
        }

        private void data_pagamento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void criarBtn_Click(object sender, EventArgs e)
        {
            var dividaAtualizada = new Divida
            {
                Situacao = situacaoEditar.Text.Trim().ToUpperInvariant(),
                DataPagamento = data_pagamento.Value.Date.ToUniversalTime()
            };
            bool sucesso = await service.AtualizarSituacaoDivida(cpfOriginal, dividaAtualizada);
            if (sucesso)
            {
                MessageBox.Show("Dívida atualizada com sucesso.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar a dívida.");
            }
        }
    }
}
