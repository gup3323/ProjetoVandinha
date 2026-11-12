using Projeto_Vandinha.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto_Vandinha.Desktop.Screens
{
    public partial class CriarDivida : Form
    {
        private readonly DividaService service;

        public CriarDivida(DividaService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void cpf_TextChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void lblMensagemStatus_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

        private async void criarBtn_Click(object sender, EventArgs e)
        {
            criarBtn.Enabled = false;

            try
            {
                int resultado = await service.CriarDivida(cpf.Text, numericUpDown1.Value, data_pagamento.Value.Date);

                if (resultado == 1)
                {
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "CPF inválido ou cliente não cadastrado.";
                }
                else if (resultado == 2)
                {
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "Cliente já possui uma dívida em aberto.";
                }
                else if (resultado == 3)
                {
                    lblMensagemStatus.ForeColor = Color.Red;
                    lblMensagemStatus.Visible = true;
                    lblMensagemStatus.Text = "O valor da dívida deve ser maior que zero.";
                }
                else
                {
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

        private void CriarDivida_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0m;
            numericUpDown1.Maximum = 1000000m;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 0.01m;
            numericUpDown1.ThousandsSeparator = true;
            numericUpDown1.Value = 0m;
            data_pagamento.Value = DateTime.Today;
        }
    }
}