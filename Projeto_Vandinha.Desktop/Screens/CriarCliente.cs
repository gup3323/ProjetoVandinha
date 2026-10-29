using Projeto_Vandinha.Models;
using Projeto_Vandinha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                DataNascimento = DateTime.SpecifyKind(data_nascimento.Value, DateTimeKind.Utc)
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
                    errorProvider1.SetError(cpf, "Dados do cliente inválidos.");
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
                    lblMensagemStatus.ForeColor = Color.DarkGreen;
                    lblMensagemStatus.Text = "Cliente cadastrado com sucesso!";
                    lblMensagemStatus.Visible = true;

                    cpf.Clear();
                    nome_completo.Clear();
                    e_mail.Clear();
                    data_nascimento.Value = DateTime.Today;
                    cpf.Focus();
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
