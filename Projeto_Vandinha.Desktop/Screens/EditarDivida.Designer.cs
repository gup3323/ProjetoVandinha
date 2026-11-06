namespace Projeto_Vandinha.Desktop.Screens
{
    partial class EditarDivida
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
            label3 = new Label();
            label1 = new Label();
            lblMensagemStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            criarBtn = new Button();
            data_pagamento = new DateTimePicker();
            situacaoEditar = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(344, 101);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 11;
            label3.Text = "Data de pagamento:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(796, 46);
            label1.TabIndex = 0;
            label1.Text = "Preencha a data que foi efetuaddo o pagamento";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // lblMensagemStatus
            // 
            lblMensagemStatus.Anchor = AnchorStyles.Top;
            lblMensagemStatus.AutoSize = true;
            lblMensagemStatus.Font = new Font("Segoe UI", 12F);
            lblMensagemStatus.Location = new Point(328, 324);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(criarBtn, 0, 6);
            tableLayoutPanel1.Controls.Add(lblMensagemStatus, 0, 7);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(data_pagamento, 0, 3);
            tableLayoutPanel1.Controls.Add(situacaoEditar, 0, 5);
            tableLayoutPanel1.Location = new Point(-1, -1);
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
            tableLayoutPanel1.Size = new Size(802, 452);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // criarBtn
            // 
            criarBtn.Anchor = AnchorStyles.Top;
            criarBtn.BackColor = Color.Lime;
            criarBtn.Font = new Font("Segoe UI", 10F);
            criarBtn.ForeColor = Color.Black;
            criarBtn.Location = new Point(326, 281);
            criarBtn.Name = "criarBtn";
            criarBtn.Size = new Size(150, 40);
            criarBtn.TabIndex = 5;
            criarBtn.Text = "Salvar";
            criarBtn.UseVisualStyleBackColor = false;
            criarBtn.Click += criarBtn_Click;
            // 
            // data_pagamento
            // 
            data_pagamento.Anchor = AnchorStyles.Top;
            data_pagamento.CustomFormat = "";
            data_pagamento.Format = DateTimePickerFormat.Short;
            data_pagamento.Location = new Point(326, 124);
            data_pagamento.MaxDate = new DateTime(2099, 10, 25, 0, 0, 0, 0);
            data_pagamento.Name = "data_pagamento";
            data_pagamento.Size = new Size(150, 23);
            data_pagamento.TabIndex = 6;
            data_pagamento.Value = new DateTime(2026, 10, 29, 0, 0, 0, 0);
            data_pagamento.ValueChanged += data_pagamento_ValueChanged;
            // 
            // situacaoEditar
            // 
            situacaoEditar.Location = new Point(3, 212);
            situacaoEditar.Name = "situacaoEditar";
            situacaoEditar.Size = new Size(100, 23);
            situacaoEditar.TabIndex = 12;
            situacaoEditar.Visible = false;
            // 
            // EditarDivida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "EditarDivida";
            Text = "EditarDivida";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Label label1;
        private Label lblMensagemStatus;
        private TableLayoutPanel tableLayoutPanel1;
        private Button criarBtn;
        private DateTimePicker data_pagamento;
        private TextBox situacaoEditar;
    }
}