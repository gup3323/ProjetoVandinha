using Projeto_Vandinha.Desktop.Screens;
using Projeto_Vandinha.Services;

namespace Projeto_Vandinha.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ClienteService service;
        private readonly DividaService serviceDivida;
        public Form1()
        {
            InitializeComponent();
            this.service = new ClienteService();

            this.serviceDivida = new DividaService();
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

        private void botaoBuscar2_Click(object sender, EventArgs e)
        {
            var tela = new ExibirDivida(serviceDivida);
            tela.ShowDialog(this);
        }
        private void botaoSalvar2_Click(object sender, EventArgs e)
        {
            var tela = new CriarDivida(serviceDivida);
            tela.ShowDialog(this);
        }

        private void botaoSalvar2_Click_1(object sender, EventArgs e)
        {
            var tela = new CriarDivida(serviceDivida);
            tela.ShowDialog(this);
        }
    }
}
