using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class EditarDivida : Form
    {
        private readonly int idDivida;
        private readonly DividaService service;

        public EditarDivida(int idDivida)
        {
            InitializeComponent();
            service = new DividaService();
            this.idDivida = idDivida;
            _ = CarregarDadosDoBancoAsync(this.idDivida);
        }

        private async Task CarregarDadosDoBancoAsync(int id)
        {
            var divida = await service.BuscarDividaPorId(id);

            if (divida != null)
            {
                situacaoEditar.Text = "PAGO";
                data_pagamento.Value = divida.DataPagamento ?? DateTime.Today;
            }
            else
            {
                MessageBox.Show("Dívida não encontrada no banco de dados.");
                this.Close();
            }
        }

        private void data_pagamento_ValueChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private async void criarBtn_Click(object sender, EventArgs e)
        {
            var dividaAtualizada = new Divida
            {
                Situacao = "PAGO",
                DataPagamento = data_pagamento.Value.Date
            };

            bool sucesso = await service.AtualizarSituacaoDivida(idDivida, dividaAtualizada);

            if (sucesso)
            {
                MessageBox.Show("Pagamento registrado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha ao atualizar a dívida.");
            }
        }
    }
}