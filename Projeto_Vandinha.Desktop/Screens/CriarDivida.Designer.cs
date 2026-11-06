namespace Projeto_Vandinha.Desktop.Screens
{
    partial class CriarDivida
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
            label1 = new Label();
            lblMensagemStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            cpf = new TextBox();
            criarBtn = new Button();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            data_pagamento = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(795, 31);
            label1.TabIndex = 0;
            label1.Text = "Preencha todos os campos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMensagemStatus
            // 
            lblMensagemStatus.Anchor = AnchorStyles.Top;
            lblMensagemStatus.AutoSize = true;
            lblMensagemStatus.Font = new Font("Segoe UI", 12F);
            lblMensagemStatus.Location = new Point(327, 231);
            lblMensagemStatus.Name = "lblMensagemStatus";
            lblMensagemStatus.Size = new Size(146, 21);
            lblMensagemStatus.TabIndex = 8;
            lblMensagemStatus.Text = "lblMensagemStatus";
            lblMensagemStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblMensagemStatus.Visible = false;
            lblMensagemStatus.Click += lblMensagemStatus_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label3, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cpf, 0, 1);
            tableLayoutPanel1.Controls.Add(criarBtn, 0, 6);
            tableLayoutPanel1.Controls.Add(lblMensagemStatus, 0, 7);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(data_pagamento, 0, 5);
            tableLayoutPanel1.Location = new Point(0, -1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.7841721F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.19424438F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.8201447F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.83453226F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.8201447F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 125F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(801, 359);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(343, 127);
            label3.Name = "label3";
            label3.Size = new Size(114, 12);
            label3.TabIndex = 11;
            label3.Text = "Data de pagamento:";
            label3.Click += label3_Click;
            // 
            // cpf
            // 
            cpf.AccessibleDescription = "";
            cpf.AccessibleName = "";
            cpf.Anchor = AnchorStyles.Top;
            cpf.BackColor = Color.White;
            cpf.Location = new Point(325, 34);
            cpf.Name = "cpf";
            cpf.PlaceholderText = "CPF";
            cpf.Size = new Size(150, 23);
            cpf.TabIndex = 1;
            cpf.TextChanged += cpf_TextChanged;
            // 
            // criarBtn
            // 
            criarBtn.Anchor = AnchorStyles.Top;
            criarBtn.BackColor = Color.Lime;
            criarBtn.Font = new Font("Segoe UI", 10F);
            criarBtn.ForeColor = Color.Black;
            criarBtn.Location = new Point(325, 188);
            criarBtn.Name = "criarBtn";
            criarBtn.Size = new Size(150, 40);
            criarBtn.TabIndex = 5;
            criarBtn.Text = "Criar";
            criarBtn.UseVisualStyleBackColor = false;
            criarBtn.Click += criarBtn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.SetColumnSpan(numericUpDown1, 2);
            numericUpDown1.Location = new Point(327, 84);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(146, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(333, 68);
            label2.Name = "label2";
            label2.Size = new Size(135, 13);
            label2.TabIndex = 10;
            label2.Text = "Digite  o valor da Divida:";
            label2.Click += label2_Click;
            // 
            // data_pagamento
            // 
            data_pagamento.Anchor = AnchorStyles.Top;
            data_pagamento.CustomFormat = "";
            data_pagamento.Format = DateTimePickerFormat.Short;
            data_pagamento.Location = new Point(325, 142);
            data_pagamento.MaxDate = new DateTime(2099, 10, 25, 0, 0, 0, 0);
            data_pagamento.Name = "data_pagamento";
            data_pagamento.Size = new Size(150, 23);
            data_pagamento.TabIndex = 6;
            data_pagamento.Value = new DateTime(2026, 10, 29, 0, 0, 0, 0);
            // 
            // CriarDivida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "CriarDivida";
            Text = "Form1";
            Load += CriarDivida_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lblMensagemStatus;
        private TableLayoutPanel tableLayoutPanel1;


        private TextBox cpf;
        private Button criarBtn;
        private DateTimePicker data_pagamento;
        private NumericUpDown numericUpDown1;
        private Label label_2;
        private Label label_3;
        private Label label3;
        private Label label2;
    }
}