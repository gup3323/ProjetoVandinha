namespace Projeto_Vandinha.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Components.BotaoBuscar botaoBuscar1;
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            botaoBuscar2 = new Projeto_Vandinha.Desktop.Components.BotaoBuscar();
            botaoSalvar1 = new Projeto_Vandinha.Desktop.Components.BotaoSalvar();
            botaoSalvar2 = new Projeto_Vandinha.Desktop.Components.BotaoSalvar();
            label1 = new Label();
            botaoBuscar1 = new Projeto_Vandinha.Desktop.Components.BotaoBuscar();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // botaoBuscar1
            // 
            botaoBuscar1.Anchor = AnchorStyles.Top;
            botaoBuscar1.BackColor = Color.FromArgb(0, 123, 255);
            botaoBuscar1.Cursor = Cursors.Hand;
            botaoBuscar1.FlatAppearance.BorderSize = 0;
            botaoBuscar1.FlatStyle = FlatStyle.Flat;
            botaoBuscar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoBuscar1.ForeColor = Color.White;
            botaoBuscar1.Location = new Point(237, 139);
            botaoBuscar1.Margin = new Padding(5);
            botaoBuscar1.Name = "botaoBuscar1";
            botaoBuscar1.Size = new Size(166, 38);
            botaoBuscar1.TabIndex = 4;
            botaoBuscar1.Text = "Exibir Clientes";
            botaoBuscar1.UseVisualStyleBackColor = false;
            botaoBuscar1.UseWaitCursor = true;
            botaoBuscar1.Click += botaoBuscar1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(botaoBuscar1, 0, 1);
            tableLayoutPanel1.Controls.Add(botaoSalvar2, 1, 2);
            tableLayoutPanel1.Controls.Add(botaoSalvar1, 0, 2);
            tableLayoutPanel1.Controls.Add(botaoBuscar2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 47);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1282, 403);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 15F, FontStyle.Bold);
            label3.Location = new Point(919, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 26);
            label3.TabIndex = 1;
            label3.Text = "Dividas";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 15F, FontStyle.Bold);
            label2.Location = new Point(274, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 26);
            label2.TabIndex = 0;
            label2.Text = "Clientes";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // botaoBuscar2
            // 
            botaoBuscar2.Anchor = AnchorStyles.Top;
            botaoBuscar2.BackColor = Color.FromArgb(0, 123, 255);
            botaoBuscar2.Cursor = Cursors.Hand;
            botaoBuscar2.FlatAppearance.BorderSize = 0;
            botaoBuscar2.FlatStyle = FlatStyle.Flat;
            botaoBuscar2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoBuscar2.ForeColor = Color.White;
            botaoBuscar2.Location = new Point(878, 139);
            botaoBuscar2.Margin = new Padding(5);
            botaoBuscar2.Name = "botaoBuscar2";
            botaoBuscar2.Size = new Size(166, 38);
            botaoBuscar2.TabIndex = 5;
            botaoBuscar2.Text = "Exibir Dividas";
            botaoBuscar2.UseVisualStyleBackColor = false;
            // 
            // botaoSalvar1
            // 
            botaoSalvar1.Anchor = AnchorStyles.Top;
            botaoSalvar1.BackColor = Color.FromArgb(40, 167, 69);
            botaoSalvar1.Cursor = Cursors.Hand;
            botaoSalvar1.FlatAppearance.BorderSize = 0;
            botaoSalvar1.FlatStyle = FlatStyle.Flat;
            botaoSalvar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoSalvar1.ForeColor = Color.White;
            botaoSalvar1.Location = new Point(237, 273);
            botaoSalvar1.Margin = new Padding(5);
            botaoSalvar1.Name = "botaoSalvar1";
            botaoSalvar1.Size = new Size(166, 38);
            botaoSalvar1.TabIndex = 10;
            botaoSalvar1.Text = "Criar Cliente";
            botaoSalvar1.UseVisualStyleBackColor = false;
            botaoSalvar1.Click += botaoSalvar1_Click;
            // 
            // botaoSalvar2
            // 
            botaoSalvar2.Anchor = AnchorStyles.Top;
            botaoSalvar2.BackColor = Color.FromArgb(40, 167, 69);
            botaoSalvar2.Cursor = Cursors.Hand;
            botaoSalvar2.FlatAppearance.BorderSize = 0;
            botaoSalvar2.FlatStyle = FlatStyle.Flat;
            botaoSalvar2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            botaoSalvar2.ForeColor = Color.White;
            botaoSalvar2.Location = new Point(878, 273);
            botaoSalvar2.Margin = new Padding(5);
            botaoSalvar2.Name = "botaoSalvar2";
            botaoSalvar2.Size = new Size(166, 38);
            botaoSalvar2.TabIndex = 11;
            botaoSalvar2.Text = "Criar Divida";
            botaoSalvar2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Yu Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1282, 35);
            label1.TabIndex = 0;
            label1.Text = "Bem vindo!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 450);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Página Home";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Components.BotaoBuscar botaoBuscar2;
        private Components.BotaoSalvar botaoSalvar1;
        private Components.BotaoSalvar botaoSalvar2;
    }
}
