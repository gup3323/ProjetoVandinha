namespace Projeto_Vandinha.Desktop.Screens
{
    partial class ExibirClientes
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
            CPF = new DataGridViewTextBoxColumn();
            nomeCompleto = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            dataNascimento = new DataGridViewTextBoxColumn();
            idade = new DataGridViewTextBoxColumn();
            txtBusca = new TextBox();
            botaoBuscar1 = new Projeto_Vandinha.Desktop.Components.BotaoBuscar();
            botaoExcluir1 = new Projeto_Vandinha.Desktop.Components.BotaoExcluir();
            pgAtual = new Label();
            prx = new Button();
            ant = new Button();
            botaoEditar1 = new Projeto_Vandinha.Desktop.Components.BotaoEditar();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CPF, nomeCompleto, email, dataNascimento, idade });
            dataGridView1.Location = new Point(2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(582, 446);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // CPF
            // 
            CPF.HeaderText = "CPF";
            CPF.MaxInputLength = 0;
            CPF.Name = "CPF";
            // 
            // nomeCompleto
            // 
            nomeCompleto.HeaderText = "Nome Completo";
            nomeCompleto.Name = "nomeCompleto";
            // 
            // email
            // 
            email.HeaderText = "E-mail";
            email.Name = "email";
            // 
            // dataNascimento
            // 
            dataNascimento.HeaderText = "Data de Nascimento";
            dataNascimento.Name = "dataNascimento";
            // 
            // idade
            // 
            idade.HeaderText = "Idade";
            idade.Name = "idade";
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(594, 12);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite um CPF/Nome/E-mail";
            txtBusca.Size = new Size(194, 23);
            txtBusca.TabIndex = 1;
            // 
            // botaoBuscar1
            // 
            botaoBuscar1.BackColor = Color.FromArgb(0, 123, 255);
            botaoBuscar1.FlatAppearance.BorderSize = 0;
            botaoBuscar1.FlatStyle = FlatStyle.Flat;
            botaoBuscar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoBuscar1.ForeColor = Color.Black;
            botaoBuscar1.Location = new Point(594, 43);
            botaoBuscar1.Margin = new Padding(5);
            botaoBuscar1.Name = "botaoBuscar1";
            botaoBuscar1.Size = new Size(194, 36);
            botaoBuscar1.TabIndex = 2;
            botaoBuscar1.Text = "Procurar";
            botaoBuscar1.UseVisualStyleBackColor = false;
            botaoBuscar1.Click += botaoBuscar1_Click;
            // 
            // botaoExcluir1
            // 
            botaoExcluir1.BackColor = Color.FromArgb(220, 53, 69);
            botaoExcluir1.FlatAppearance.BorderSize = 0;
            botaoExcluir1.FlatStyle = FlatStyle.Flat;
            botaoExcluir1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoExcluir1.ForeColor = Color.Black;
            botaoExcluir1.Location = new Point(594, 89);
            botaoExcluir1.Margin = new Padding(5);
            botaoExcluir1.Name = "botaoExcluir1";
            botaoExcluir1.Size = new Size(194, 38);
            botaoExcluir1.TabIndex = 3;
            botaoExcluir1.Text = "Deletar Cliente";
            botaoExcluir1.UseVisualStyleBackColor = false;
            botaoExcluir1.Click += botaoExcluir1_Click;
            // 
            // pgAtual
            // 
            pgAtual.AutoSize = true;
            pgAtual.Location = new Point(686, 429);
            pgAtual.Name = "pgAtual";
            pgAtual.Size = new Size(13, 15);
            pgAtual.TabIndex = 4;
            pgAtual.Text = "1";
            // 
            // prx
            // 
            prx.Location = new Point(738, 425);
            prx.Name = "prx";
            prx.Size = new Size(50, 23);
            prx.TabIndex = 5;
            prx.Text = ">";
            prx.UseVisualStyleBackColor = true;
            prx.Click += prx_Click;
            // 
            // ant
            // 
            ant.Location = new Point(594, 425);
            ant.Name = "ant";
            ant.Size = new Size(50, 23);
            ant.TabIndex = 6;
            ant.Text = "<";
            ant.UseVisualStyleBackColor = true;
            ant.Visible = false;
            ant.Click += ant_Click;
            // 
            // botaoEditar1
            // 
            botaoEditar1.BackColor = Color.FromArgb(255, 193, 7);
            botaoEditar1.FlatAppearance.BorderSize = 0;
            botaoEditar1.FlatStyle = FlatStyle.Flat;
            botaoEditar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoEditar1.ForeColor = Color.Black;
            botaoEditar1.Location = new Point(592, 137);
            botaoEditar1.Margin = new Padding(5);
            botaoEditar1.Name = "botaoEditar1";
            botaoEditar1.Size = new Size(196, 38);
            botaoEditar1.TabIndex = 7;
            botaoEditar1.Text = "Editar Cliente";
            botaoEditar1.UseVisualStyleBackColor = false;
            botaoEditar1.Click += botaoEditar1_Click;
            // 
            // ExibirClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(botaoEditar1);
            Controls.Add(ant);
            Controls.Add(prx);
            Controls.Add(pgAtual);
            Controls.Add(botaoExcluir1);
            Controls.Add(botaoBuscar1);
            Controls.Add(txtBusca);
            Controls.Add(dataGridView1);
            Name = "ExibirClientes";
            Text = "ExibirClientes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtBusca;
        private Components.BotaoBuscar botaoBuscar1;
        private Components.BotaoExcluir botaoExcluir1;
        private Label pgAtual;
        private Button prx;
        private Button ant;
        private Components.BotaoEditar botaoEditar1;
        private DataGridViewTextBoxColumn CPF;
        private DataGridViewTextBoxColumn nomeCompleto;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn dataNascimento;
        private DataGridViewTextBoxColumn idade;
    }
}