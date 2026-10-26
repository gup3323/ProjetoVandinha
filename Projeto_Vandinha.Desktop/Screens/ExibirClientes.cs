using Microsoft.EntityFrameworkCore;
using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;

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
            await CarregarDados();
        }

        private async Task CarregarDados()
        {
            int paginaAtual = 1;
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
                    cliente.Email,
                    cliente.DataNascimento,
                    cliente.Idade
                );
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void botaoBuscar1_Click(object sender, EventArgs e)
        {
            var cliente = await service.BuscarClientePorCpf(txtBusca.Text);
            if (txtBusca.Text == "")
            {
                CarregarDados();
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
                ant.Visible = true;
                paginaAtual--;
                var clientes = await service.ListarClientes(paginaAtual);
                CarregarTabela(clientes);
                pgAtual.Text = paginaAtual.ToString();
            }
        }

        private void botaoExcluir1_Click(object sender, EventArgs e)
        {
            var clienteExcluir = service.BuscarClientePorCpf(txtBusca.Text);
            if (clienteExcluir != null)
            {
                var confirmResult = MessageBox.Show($"Tem certeza que deseja excluir cliente de CPF {txtBusca.Text}?", "Confirmação de exclusão", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    service.DeletarCliente(txtBusca.Text);
                    MessageBox.Show("Cliente excluído com sucesso!");
                    txtBusca.Clear();
                    dataGridView1.Rows.Clear();
                    CarregarDados();
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
            }
        }

        private async void botaoEditar1_Click(object sender, EventArgs e)
        {
            
            var clienteSelecionado = await service.BuscarClientePorCpf(txtBusca.Text);
            if (clienteSelecionado != null)
            {
                var telaEdicao = new EditarCliente(clienteSelecionado.Cpf);
                telaEdicao.ShowDialog(this);
                CarregarDados();
            }
        }
    }
}
