using Projeto_Vandinha.Desktop.Screens;
using Projeto_Vandinha.Services;

namespace Projeto_Vandinha.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ClienteService service;
        public Form1()
        {
            InitializeComponent();
            this.service = new ClienteService();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void botaoBuscar1_Click(object sender, EventArgs e)
        {
            var tela = new ExibirClientes(service);
            tela.ShowDialog(this);
        }

        private void botaoSalvar1_Click(object sender, EventArgs e)
        {
            var tela = new CriarCliente(service);
            tela.ShowDialog(this);
        }
    }
}
