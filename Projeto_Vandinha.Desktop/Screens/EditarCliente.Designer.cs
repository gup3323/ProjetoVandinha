namespace Projeto_Vandinha.Desktop.Screens
{
    partial class EditarCliente
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
            e_mail = new TextBox();
            label1 = new Label();
            cpf = new TextBox();
            criarBtn = new Button();
            data_nascimento = new DateTimePicker();
            nome_completo = new TextBox();
            lblMensagemStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            emailEditar = new TextBox();
            label2 = new Label();
            cpfEditar = new TextBox();
            button1 = new Button();
            dataNascimentoEditar = new DateTimePicker();
            nomeCompletoEditar = new TextBox();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // e_mail
            // 
            e_mail.Anchor = AnchorStyles.Top;
            e_mail.BackColor = Color.White;
            e_mail.Location = new Point(488, 289);
            e_mail.Name = "e_mail";
            e_mail.PlaceholderText = "E-mail";
            e_mail.Size = new Size(150, 23);
            e_mail.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 37);
            label1.TabIndex = 9;
            label1.Text = "Preencha todos os campos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpf
            // 
            cpf.AccessibleDescription = "";
            cpf.AccessibleName = "";
            cpf.Anchor = AnchorStyles.Top;
            cpf.BackColor = Color.White;
            cpf.Location = new Point(488, 76);
            cpf.Name = "cpf";
            cpf.PlaceholderText = "CPF";
            cpf.Size = new Size(150, 23);
            cpf.TabIndex = 10;
            // 
            // criarBtn
            // 
            criarBtn.Anchor = AnchorStyles.Top;
            criarBtn.BackColor = Color.Lime;
            criarBtn.Font = new Font("Segoe UI", 10F);
            criarBtn.ForeColor = Color.Black;
            criarBtn.Location = new Point(488, 360);
            criarBtn.Name = "criarBtn";
            criarBtn.Size = new Size(150, 40);
            criarBtn.TabIndex = 12;
            criarBtn.Text = "Criar";
            criarBtn.UseVisualStyleBackColor = false;
            // 
            // data_nascimento
            // 
            data_nascimento.Anchor = AnchorStyles.Top;
            data_nascimento.CustomFormat = "";
            data_nascimento.Format = DateTimePickerFormat.Short;
            data_nascimento.Location = new Point(488, 218);
            data_nascimento.MaxDate = new DateTime(2026, 10, 25, 0, 0, 0, 0);
            data_nascimento.Name = "data_nascimento";
            data_nascimento.Size = new Size(150, 23);
            data_nascimento.TabIndex = 13;
            data_nascimento.Value = new DateTime(2026, 10, 25, 0, 0, 0, 0);
            // 
            // nome_completo
            // 
            nome_completo.Anchor = AnchorStyles.Top;
            nome_completo.Location = new Point(488, 147);
            nome_completo.Name = "nome_completo";
            nome_completo.PlaceholderText = "Nome Completo";
            nome_completo.ShortcutsEnabled = false;
            nome_completo.Size = new Size(150, 23);
            nome_completo.TabIndex = 14;
            // 
            // lblMensagemStatus
            // 
            lblMensagemStatus.Anchor = AnchorStyles.Top;
            lblMensagemStatus.AutoSize = true;
            lblMensagemStatus.Font = new Font("Segoe UI", 12F);
            lblMensagemStatus.Location = new Point(490, 428);
            lblMensagemStatus.Name = "lblMensagemStatus";
            lblMensagemStatus.Size = new Size(146, 21);
            lblMensagemStatus.TabIndex = 15;
            lblMensagemStatus.Text = "lblMensagemStatus";
            lblMensagemStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblMensagemStatus.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(emailEditar, 0, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(cpfEditar, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 5);
            tableLayoutPanel1.Controls.Add(dataNascimentoEditar, 0, 3);
            tableLayoutPanel1.Controls.Add(nomeCompletoEditar, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 6);
            tableLayoutPanel1.Location = new Point(-1, -1);
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
            tableLayoutPanel1.TabIndex = 16;
            // 
            // emailEditar
            // 
            emailEditar.Anchor = AnchorStyles.Top;
            emailEditar.BackColor = Color.White;
            emailEditar.Location = new Point(326, 287);
            emailEditar.Name = "emailEditar";
            emailEditar.PlaceholderText = "E-mail";
            emailEditar.Size = new Size(150, 23);
            emailEditar.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(796, 71);
            label2.TabIndex = 0;
            label2.Text = "Preencha os campos que deseja editar";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpfEditar
            // 
            cpfEditar.AccessibleDescription = "";
            cpfEditar.AccessibleName = "";
            cpfEditar.Anchor = AnchorStyles.Top;
            cpfEditar.BackColor = Color.White;
            cpfEditar.Location = new Point(326, 74);
            cpfEditar.Name = "cpfEditar";
            cpfEditar.PlaceholderText = "CPF";
            cpfEditar.ReadOnly = true;
            cpfEditar.Size = new Size(150, 23);
            cpfEditar.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(326, 358);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 5;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataNascimentoEditar
            // 
            dataNascimentoEditar.Anchor = AnchorStyles.Top;
            dataNascimentoEditar.CustomFormat = "";
            dataNascimentoEditar.Format = DateTimePickerFormat.Short;
            dataNascimentoEditar.Location = new Point(326, 216);
            dataNascimentoEditar.MaxDate = new DateTime(2026, 10, 25, 0, 0, 0, 0);
            dataNascimentoEditar.Name = "dataNascimentoEditar";
            dataNascimentoEditar.Size = new Size(150, 23);
            dataNascimentoEditar.TabIndex = 6;
            dataNascimentoEditar.Value = new DateTime(2026, 10, 25, 0, 0, 0, 0);
            // 
            // nomeCompletoEditar
            // 
            nomeCompletoEditar.Anchor = AnchorStyles.Top;
            nomeCompletoEditar.Location = new Point(326, 145);
            nomeCompletoEditar.Name = "nomeCompletoEditar";
            nomeCompletoEditar.PlaceholderText = "Nome Completo";
            nomeCompletoEditar.ShortcutsEnabled = false;
            nomeCompletoEditar.Size = new Size(150, 23);
            nomeCompletoEditar.TabIndex = 7;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(375, 426);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 8;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Visible = false;
            // 
            // EditarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(e_mail);
            Controls.Add(label1);
            Controls.Add(cpf);
            Controls.Add(criarBtn);
            Controls.Add(data_nascimento);
            Controls.Add(nome_completo);
            Controls.Add(lblMensagemStatus);
            Name = "EditarCliente";
            Text = "EditarCliente";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox e_mail;
        private Label label1;
        private TextBox cpf;
        private Button criarBtn;
        private DateTimePicker data_nascimento;
        private TextBox nome_completo;
        private Label lblMensagemStatus;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox emailEditar;
        private Label label2;
        private TextBox cpfEditar;
        private Button button1;
        private DateTimePicker dataNascimentoEditar;
        private TextBox nomeCompletoEditar;
        private Label label3;
    }
}