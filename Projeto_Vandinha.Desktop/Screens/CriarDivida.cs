using Projeto_Vandinha.Services;
using Projeto_Vandinha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class CriarDivida : Form
    {

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void cpf_TextChanged(object sender, EventArgs e)
        {
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) 
        { 
        }
        private void lblMensagemStatus_Click(object sender, EventArgs e)
        {
        }


        private readonly DividaService service;
        public CriarDivida( DividaService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private async void criarBtn_Click(object sender, EventArgs e)
        {
            criarBtn.Enabled = false;
            var divida = new Divida
            {
                //id_divida = 0,
                CpfCliente = cpf.Text,
                Valor = (int)numericUpDown1.Value,
                Situacao = "pendente".ToUpper(),
                DataCriacao = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                DataPagamento = DateTime.SpecifyKind(data_pagamento.Value, DateTimeKind.Utc)
            };
            try
            {
                int resultado = service.CriarDivida(divida.CpfCliente, divida.Valor, divida.DataPagamento);
                if (resultado == 1)
                {
                    lblMensagemStatus = new Label();
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "CPF inválido.";
                }
                else if (resultado == 2)
                {
                    lblMensagemStatus = new Label();
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "Cliente já possui uma dívida em aberto.";
                }
                else
                {
                    //MessageBox.Show("Dívida criada com sucesso!");
                    lblMensagemStatus.ForeColor = Color.DarkGreen;
                    lblMensagemStatus.Text = "Dívida cadastrada com sucesso!";
                    lblMensagemStatus.Visible = true;

                    cpf.Clear();
                    numericUpDown1.Value = 0;
                    data_pagamento.Value = DateTime.Today;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao criar a dívida: {ex.Message}");
                lblMensagemStatus.ForeColor = Color.Red;
                lblMensagemStatus.Text = "Ocorreu um erro ao criar a dívida.";
                lblMensagemStatus.Visible = true;
            }
            finally
            {
                criarBtn.Enabled = true;
            }

        }
    }
}
