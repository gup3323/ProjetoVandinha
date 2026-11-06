namespace Projeto_Vandinha.Desktop.Screens
{
    partial class ExibirDivida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CPF = new DataGridViewTextBoxColumn();
            situacaoDivida = new DataGridViewTextBoxColumn();
            dataPagamento = new DataGridViewTextBoxColumn();
            valorDivida = new DataGridViewTextBoxColumn();
            dataCriacao = new DataGridViewTextBoxColumn();
            botaoEditar1 = new Projeto_Vandinha.Desktop.Components.BotaoEditar();
            ant = new Button();
            prx = new Button();
            pgAtual = new Label();
            botaoBuscar1 = new Projeto_Vandinha.Desktop.Components.BotaoBuscar();
            txtBusca = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, CPF, situacaoDivida, dataPagamento, valorDivida, dataCriacao });
            dataGridView1.Location = new Point(7, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(582, 446);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // CPF
            // 
            CPF.HeaderText = "CPF";
            CPF.MaxInputLength = 0;
            CPF.Name = "CPF";
            // 
            // situacaoDivida
            // 
            situacaoDivida.HeaderText = "Situação Divida";
            situacaoDivida.Name = "situacaoDivida";
            // 
            // dataPagamento
            // 
            dataPagamento.HeaderText = "Data Pagamento";
            dataPagamento.Name = "dataPagamento";
            // 
            // valorDivida
            // 
            valorDivida.HeaderText = "Valor Divida";
            valorDivida.Name = "valorDivida";
            // 
            // dataCriacao
            // 
            dataCriacao.HeaderText = "Data Criação";
            dataCriacao.Name = "dataCriacao";
            // 
            // botaoEditar1
            // 
            botaoEditar1.BackColor = Color.FromArgb(255, 193, 7);
            botaoEditar1.FlatAppearance.BorderSize = 0;
            botaoEditar1.FlatStyle = FlatStyle.Flat;
            botaoEditar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoEditar1.ForeColor = Color.Black;
            botaoEditar1.Location = new Point(599, 89);
            botaoEditar1.Margin = new Padding(5);
            botaoEditar1.Name = "botaoEditar1";
            botaoEditar1.Size = new Size(196, 38);
            botaoEditar1.TabIndex = 15;
            botaoEditar1.Text = "Editar Cliente";
            botaoEditar1.UseVisualStyleBackColor = false;
            botaoEditar1.Click += botaoEditar1_Click;
            // 
            // ant
            // 
            ant.Location = new Point(599, 425);
            ant.Name = "ant";
            ant.Size = new Size(50, 23);
            ant.TabIndex = 14;
            ant.Text = "<";
            ant.UseVisualStyleBackColor = true;
            ant.Visible = false;
            ant.Click += ant_Click;
            // 
            // prx
            // 
            prx.Location = new Point(743, 425);
            prx.Name = "prx";
            prx.Size = new Size(50, 23);
            prx.TabIndex = 13;
            prx.Text = ">";
            prx.UseVisualStyleBackColor = true;
            prx.Click += prx_Click_1;
            // 
            // pgAtual
            // 
            pgAtual.AutoSize = true;
            pgAtual.Location = new Point(691, 429);
            pgAtual.Name = "pgAtual";
            pgAtual.Size = new Size(13, 15);
            pgAtual.TabIndex = 12;
            pgAtual.Text = "1";
            // 
            // botaoBuscar1
            // 
            botaoBuscar1.BackColor = Color.FromArgb(0, 123, 255);
            botaoBuscar1.FlatAppearance.BorderSize = 0;
            botaoBuscar1.FlatStyle = FlatStyle.Flat;
            botaoBuscar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoBuscar1.ForeColor = Color.Black;
            botaoBuscar1.Location = new Point(599, 43);
            botaoBuscar1.Margin = new Padding(5);
            botaoBuscar1.Name = "botaoBuscar1";
            botaoBuscar1.Size = new Size(194, 36);
            botaoBuscar1.TabIndex = 10;
            botaoBuscar1.Text = "Procurar";
            botaoBuscar1.UseVisualStyleBackColor = false;
            botaoBuscar1.Click += botaoBuscar1_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(599, 12);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite um CPF";
            txtBusca.Size = new Size(194, 23);
            txtBusca.TabIndex = 9;
            // 
            // ExibirDivida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(botaoEditar1);
            Controls.Add(ant);
            Controls.Add(prx);
            Controls.Add(pgAtual);
            Controls.Add(botaoBuscar1);
            Controls.Add(txtBusca);
            Name = "ExibirDivida";
            Text = "ExibirDivida";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Components.BotaoEditar botaoEditar1;
        private Button ant;
        private Button prx;
        private Label pgAtual;
        private Components.BotaoBuscar botaoBuscar1;
        private TextBox txtBusca;
        private DataGridViewTextBoxColumn CPF;
        private DataGridViewTextBoxColumn situacaoDivida;
        private DataGridViewTextBoxColumn dataPagamento;
        private DataGridViewTextBoxColumn valorDivida;
        private DataGridViewTextBoxColumn dataCriacao;
        private DataGridViewTextBoxColumn ID;
    }
}