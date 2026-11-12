using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class ExibirClientes : Form
    {
        private readonly ClienteService service;

        public ExibirClientes(ClienteService service)
        {
            InitializeComponent();
            this.service = service;
            Load += ExibirClientes_Load;
        }

        private async void ExibirClientes_Load(object? sender, EventArgs e)
        {
            // Garante que exista a coluna de Total de Dívidas caso não tenha sido criada no Designer
            if (dataGridView1.Columns.Count == 5)
            {
                dataGridView1.Columns.Add("colTotalDividas", "Total Dívidas (R$)");
            }

            pgAtual.Text = "1";
            await CarregarDados();
        }

        private async Task CarregarDados()
        {
            int paginaAtual = int.TryParse(pgAtual.Text, out int pg) && pg > 0 ? pg : 1;
            var clientes = await service.ListarClientes(paginaAtual);
            CarregarTabela(clientes);
        }

        private void CarregarTabela(List<Cliente> clientes)
        {
            dataGridView1.Rows.Clear();

            foreach (var cliente in clientes)
            {
                dataGridView1.Rows.Add(
                    cliente.Cpf,
                    cliente.NomeCompleto,
                    cliente.Email ?? "-",
                    cliente.DataNascimento.ToString("dd/MM/yyyy"),
                    cliente.Idade,
                    cliente.TotalDividasEmAberto.ToString("C2")
                );
            }
        }

        private string ObterCpfAlvo()
        {
            if (!string.IsNullOrWhiteSpace(txtBusca.Text))
                return txtBusca.Text.Trim();

            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
                return dataGridView1.CurrentRow.Cells[0].Value.ToString() ?? string.Empty;

            return string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                txtBusca.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private async void botaoBuscar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                pgAtual.Text = "1";
                await CarregarDados();
            }
            else
            {
                var resultados = await service.BuscarClientes(txtBusca.Text);
                CarregarTabela(resultados);
            }
        }

        private async void prx_Click(object sender, EventArgs e)
        {
            int paginaAtual = int.Parse(pgAtual.Text);
            paginaAtual++;
            var clientes = await service.ListarClientes(paginaAtual);

            if (clientes.Count > 0)
            {
                ant.Visible = true;
                CarregarTabela(clientes);
                pgAtual.Text = paginaAtual.ToString();
            }
        }

        private async void ant_Click(object sender, EventArgs e)
        {
            int paginaAtual = int.Parse(pgAtual.Text);
            if (paginaAtual > 1)
            {
                paginaAtual--;
                var clientes = await service.ListarClientes(paginaAtual);
                CarregarTabela(clientes);
                pgAtual.Text = paginaAtual.ToString();
            }
        }

        private async void botaoExcluir1_Click(object sender, EventArgs e)
        {
            string cpfAlvo = ObterCpfAlvo();
            var clienteExcluir = await service.BuscarClientePorCpf(cpfAlvo);

            if (clienteExcluir != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Tem certeza que deseja excluir o cliente {clienteExcluir.NomeCompleto} (CPF {clienteExcluir.Cpf})?",
                    "Confirmação de exclusão",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    bool deletado = await service.DeletarCliente(clienteExcluir.Cpf);
                    if (deletado)
                    {
                        MessageBox.Show("Cliente excluído com sucesso!");
                        txtBusca.Clear();
                        await CarregarDados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela ou digite o CPF para excluir.");
            }
        }

        private async void botaoEditar1_Click(object sender, EventArgs e)
        {
            string cpfAlvo = ObterCpfAlvo();
            var clienteSelecionado = await service.BuscarClientePorCpf(cpfAlvo);

            if (clienteSelecionado != null)
            {
                var telaEdicao = new EditarCliente(clienteSelecionado.Cpf);
                telaEdicao.ShowDialog(this);
                await CarregarDados();
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela ou digite o CPF para editar.");
            }
        }
    }
}