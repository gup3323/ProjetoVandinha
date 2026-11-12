using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class CriarCliente : Form
    {
        private readonly ClienteService service;

        public CriarCliente(ClienteService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private async void criarBtn_Click(object sender, EventArgs e)
        {
            criarBtn.Enabled = false;
            errorProvider1.Clear();

            var cliente = new Cliente
            {
                Cpf = cpf.Text,
                NomeCompleto = nome_completo.Text,
                Email = e_mail.Text,
                DataNascimento = data_nascimento.Value.Date
            };

            try
            {
                int resultado = await service.CriarCliente(cliente);
                if (resultado == 1)
                {
                    errorProvider1.SetError(cpf, "CPF inválido.");
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "CPF inválido.";
                }
                else if (resultado == 2)
                {
                    errorProvider1.SetError(nome_completo, "Dados do cliente inválidos (verifique nome, idade 15-100 e e-mail).");
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "Dados do cliente inválidos.";
                }
                else if (resultado == 3)
                {
                    errorProvider1.SetError(cpf, "Cliente com este CPF já existe.");
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "Cliente com este CPF já existe.";
                }
                else
                {
                    MessageBox.Show("Cliente criado com sucesso!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar cliente: {ex.Message}");
                lblMensagemStatus.ForeColor = Color.Red;
                lblMensagemStatus.Text = "Erro ao criar cliente.";
                lblMensagemStatus.Visible = true;
            }
            finally
            {
                criarBtn.Enabled = true;
            }
        }
    }
}