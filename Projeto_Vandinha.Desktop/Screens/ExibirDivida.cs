using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Projeto_Vandinha.Models;

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

        private async void ExibirDivida_Load(object sender, EventArgs e)
        {
            await CarregarDados();
        }

        private async Task CarregarDados()
        {
            int paginaAtual = 1;
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
                    divida.Situacao == "PAGO".ToUpper() ? "Pago".ToUpper() : "Pendente".ToUpper(),
                    divida.DataPagamento.ToString("dd/MM/yyyy") ?? "N/A",
                    divida.Valor,
                    divida.DataCriacao.ToString("dd/MM/yyyy")
                );
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void botaoBuscar2_Click(object sender, EventArgs e)
        {
            var divida = await dividaService.BuscarDividaPorCpf(txtBusca.Text);
            if (txtBusca.Text == "")
            {
                CarregarDados();
            }
            else
            {
                var resultados = await dividaService.BuscarDividas(txtBusca.Text);
                CarregarTabela(resultados);
            }
        }

        private async void botaoBuscar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                CarregarDados();
            }
            else
            {
                var resultados = await dividaService.BuscarDividas(txtBusca.Text);

                CarregarTabela(resultados);
            }
        }

        private async void botaoEditar1_Click(object sender, EventArgs e)
        {
            var dividaSelecionada = await dividaService.BuscarDividaPorCpf(txtBusca.Text);
            if (dividaSelecionada != null)
            {
                var editarDividaForm = new EditarDivida(dividaSelecionada.CpfCliente);
                editarDividaForm.ShowDialog();
                CarregarDados();
            }
            else
            {
                MessageBox.Show("Pesquise um cliente para editar.");
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
                ant.Visible = true;
                paginaAtual--;
                var dividas = await dividaService.ListarDivida(paginaAtual);
                CarregarTabela(dividas);
                pgAtual.Text = paginaAtual.ToString();
            }
        }

        //private async void prx_Click(object sender, EventArgs e)
        //{
        //    int paginaAtual = int.Parse(pgAtual.Text);
        //    paginaAtual++;
        //    var clientes = await service.ListarClientes(paginaAtual);

        //    if (clientes.Count > 0)
        //    {
        //        ant.Visible = true;
        //        CarregarTabela(clientes);
        //        pgAtual.Text = paginaAtual.ToString();
        //    }
    }
}


