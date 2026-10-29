namespace Projeto_Vandinha.Desktop.Screens
{
    partial class CriarCliente
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
            components = new System.ComponentModel.Container();
            lblMensagemStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            e_mail = new TextBox();
            label1 = new Label();
            cpf = new TextBox();
            criarBtn = new Button();
            data_nascimento = new DateTimePicker();
            nome_completo = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblMensagemStatus
            // 
            lblMensagemStatus.Anchor = AnchorStyles.Top;
            lblMensagemStatus.AutoSize = true;
            lblMensagemStatus.Font = new Font("Segoe UI", 12F);
            lblMensagemStatus.Location = new Point(328, 426);
            lblMensagemStatus.Name = "lblMensagemStatus";
            lblMensagemStatus.Size = new Size(146, 21);
            lblMensagemStatus.TabIndex = 8;
            lblMensagemStatus.Text = "lblMensagemStatus";
            lblMensagemStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblMensagemStatus.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(e_mail, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cpf, 0, 1);
            tableLayoutPanel1.Controls.Add(criarBtn, 0, 5);
            tableLayoutPanel1.Controls.Add(data_nascimento, 0, 3);
            tableLayoutPanel1.Controls.Add(nome_completo, 0, 2);
            tableLayoutPanel1.Controls.Add(lblMensagemStatus, 0, 6);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(802, 452);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // e_mail
            // 
            e_mail.Anchor = AnchorStyles.Top;
            e_mail.BackColor = Color.White;
            e_mail.Location = new Point(326, 287);
            e_mail.Name = "e_mail";
            e_mail.PlaceholderText = "E-mail";
            e_mail.Size = new Size(150, 23);
            e_mail.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(796, 71);
            label1.TabIndex = 0;
            label1.Text = "Preencha todos os campos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpf
            // 
            cpf.AccessibleDescription = "";
            cpf.AccessibleName = "";
            cpf.Anchor = AnchorStyles.Top;
            cpf.BackColor = Color.White;
            cpf.Location = new Point(326, 74);
            cpf.Name = "cpf";
            cpf.PlaceholderText = "CPF";
            cpf.Size = new Size(150, 23);
            cpf.TabIndex = 1;
            // 
            // criarBtn
            // 
            criarBtn.Anchor = AnchorStyles.Top;
            criarBtn.BackColor = Color.Lime;
            criarBtn.Font = new Font("Segoe UI", 10F);
            criarBtn.ForeColor = Color.Black;
            criarBtn.Location = new Point(326, 358);
            criarBtn.Name = "criarBtn";
            criarBtn.Size = new Size(150, 40);
            criarBtn.TabIndex = 5;
            criarBtn.Text = "Criar";
            criarBtn.UseVisualStyleBackColor = false;
            criarBtn.Click += criarBtn_Click;
            // 
            // data_nascimento
            // 
            data_nascimento.Anchor = AnchorStyles.Top;
            data_nascimento.CustomFormat = "";
            data_nascimento.Format = DateTimePickerFormat.Short;
            data_nascimento.Location = new Point(326, 216);
            data_nascimento.MaxDate = new DateTime(2099, 10, 25, 0, 0, 0, 0);
            data_nascimento.Name = "data_nascimento";
            data_nascimento.Size = new Size(150, 23);
            data_nascimento.TabIndex = 6;
            data_nascimento.Value = new DateTime(2026, 10, 29, 0, 0, 0, 0);
            // 
            // nome_completo
            // 
            nome_completo.Anchor = AnchorStyles.Top;
            nome_completo.Location = new Point(326, 145);
            nome_completo.Name = "nome_completo";
            nome_completo.PlaceholderText = "Nome Completo";
            nome_completo.ShortcutsEnabled = false;
            nome_completo.Size = new Size(150, 23);
            nome_completo.TabIndex = 7;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CriarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "CriarCliente";
            Text = "CriarCliente";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox e_mail;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox cpf;
        private Button criarBtn;
        private DateTimePicker data_nascimento;
        private ErrorProvider errorProvider1;
        private TextBox nome_completo;
        private Label lblMensagemStatus;
    }
}