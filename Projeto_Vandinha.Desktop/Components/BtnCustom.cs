using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vandinha.Desktop.Components
{
    public abstract class BotaoCrudBase : Button
    {
        public BotaoCrudBase()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(110, 38);
            this.Margin = new Padding(5);
        }
    }

    public class BotaoSalvar : BotaoCrudBase
    {
        private readonly Color _corPadrao = Color.FromArgb(40, 167, 69);
        private readonly Color _corHover = Color.FromArgb(33, 136, 56);

        public BotaoSalvar()
        {
            this.Text = "Salvar";
            this.BackColor = _corPadrao;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(50, 200, 80);
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.White;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = _corPadrao;
            this.FlatAppearance.BorderSize = 0;
        }
    }

    public class BotaoBuscar : BotaoCrudBase
    {
        private readonly Color _corPadrao = Color.FromArgb(0, 123, 255);
        private readonly Color _corHover = Color.FromArgb(0, 105, 217);

        public BotaoBuscar()
        {
            this.Text = "Buscar";
            this.BackColor = _corPadrao;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(50, 200, 80);
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.White;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = _corPadrao;
            this.FlatAppearance.BorderSize = 0;
        }
    }

    public class BotaoEditar : BotaoCrudBase
    {
        private readonly Color _corPadrao = Color.FromArgb(255, 193, 7);
        private readonly Color _corHover = Color.FromArgb(224, 168, 0);

        public BotaoEditar()
        {
            this.Text = "Editar";
            this.BackColor = _corPadrao;
            this.ForeColor = Color.FromArgb(33, 37, 41); // Texto escuro para contraste
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(50, 200, 80);
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.White;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = _corPadrao;
            this.FlatAppearance.BorderSize = 0;
        }
    }

    public class BotaoExcluir : BotaoCrudBase
    {
        private readonly Color _corPadrao = Color.FromArgb(220, 53, 69);   // Vermelho
        private readonly Color _corHover = Color.FromArgb(200, 35, 51);

        public BotaoExcluir()
        {
            this.Text = "Excluir";
            this.BackColor = _corPadrao;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(50, 200, 80);
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.White;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = _corPadrao;
            this.FlatAppearance.BorderSize = 0;
        }
    }
}
    