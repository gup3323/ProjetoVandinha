using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class ExibirDivida : Form
    {
        private readonly DividaService dividaService;

        public ExibirDivida(DividaService dividaService)
        {
            InitializeComponent();
            this.dividaService = dividaService;
            Load += ExibirDivida_Load;
        }

        private async void ExibirDivida_Load(object? sender, EventArgs e)
        {
            pgAtual.Text = "1";
            await CarregarDados();
        }

        private async Task CarregarDados()
        {
            int paginaAtual = int.TryParse(pgAtual.Text, out int pg) && pg > 0 ? pg : 1;
            var dividas = await dividaService.ListarDivida(paginaAtual);
            CarregarTabela(dividas);
        }

        private void CarregarTabela(List<Divida> dividas)
        {
            dataGridView1.Rows.Clear();
            foreach (var divida in dividas)
            {
                dataGridView1.Rows.Add(
                    divida.id_divida,
                    divida.CpfCliente,
                    divida.Situacao == "PAGO" ? "PAGO" : "PENDENTE",
                    divida.DataPagamento.HasValue ? divida.DataPagamento.Value.ToString("dd/MM/yyyy") : "N/A",
                    divida.Valor.ToString("C2"),
                    divida.DataCriacao.ToString("dd/MM/yyyy")
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            {
                txtBusca.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private async void botaoBuscar2_Click(object sender, EventArgs e)
        {
            await ExecutarBusca();
        }

        private async void botaoBuscar1_Click(object sender, EventArgs e)
        {
            await ExecutarBusca();
        }

        private async Task ExecutarBusca()
        {
            if (string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                pgAtual.Text = "1";
                await CarregarDados();
            }
            else
            {
                var resultados = await dividaService.BuscarDividas(txtBusca.Text);
                CarregarTabela(resultados);
            }
        }

        private async void botaoEditar1_Click(object sender, EventArgs e)
        {
            int? idDividaSelecionada = null;

            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                idDividaSelecionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            else if (!string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                var divida = await dividaService.BuscarDividaPorCpf(txtBusca.Text);
                if (divida != null)
                    idDividaSelecionada = divida.id_divida;
            }

            if (idDividaSelecionada.HasValue)
            {
                var editarDividaForm = new EditarDivida(idDividaSelecionada.Value);
                editarDividaForm.ShowDialog(this);
                await ExecutarBusca();
            }
            else
            {
                MessageBox.Show("Selecione uma dívida na tabela ou pesquise um cliente para marcar pagamento.");
            }
        }

        public void tableLayoutPanel1() { }

        private async void prx_Click_1(object sender, EventArgs e)
        {
            int paginaAtual = int.Parse(pgAtual.Text);
            paginaAtual++;
            var dividas = await dividaService.ListarDivida(paginaAtual);
            if (dividas.Count > 0)
            {
                ant.Visible = true;
                CarregarTabela(dividas);
                pgAtual.Text = paginaAtual.ToString();
            }
        }

        private async void ant_Click(object sender, EventArgs e)
        {
            int paginaAtual = int.Parse(pgAtual.Text);
            if (paginaAtual > 1)
            {
                paginaAtual--;
                var dividas = await dividaService.ListarDivida(paginaAtual);
                CarregarTabela(dividas);
                pgAtual.Text = paginaAtual.ToString();
            }
        }
    }
}