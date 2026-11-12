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
            this.service = new DividaService();
            this.idDivida = idDivida;
        }

        private async void EditarDivida_Load(object sender, EventArgs e)
        {
            var divida = await service.BuscarDividaPorId(idDivida);
            if (divida != null)
            {
                situacaoEditar.Text = divida.Situacao == "PAGO" ? "PAGO" : "PENDENTE";
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
                Situacao = situacaoEditar.Text.Trim().ToUpperInvariant(),
                DataPagamento = data_pagamento.Value.Date
            };

            bool sucesso = await service.AtualizarSituacaoDivida(idDivida, dividaAtualizada);
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