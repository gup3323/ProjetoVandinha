using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Projeto_Vandinha.Models
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [MinLength(11), MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome completo é obrigatório.")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "O nome deve ter entre 6 e 80 caracteres.")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "O nome deve conter apenas letras e espaços.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DataNascimento.Year;
                if (DataNascimento.Date > hoje.AddYears(-idade))
                {
                    idade--;
                }
                return idade;
            }
        }

        private string? _email;

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "O e-mail deve ter entre 6 e 80 caracteres.")]
        public string? Email
        {
            get => _email;
            set => _email = string.IsNullOrWhiteSpace(value) ? null : value.ToLower().Trim();
        }

        public List<Divida> Dividas { get; set; } = new();

        [NotMapped]
        public decimal TotalDividasEmAberto => Dividas
            .Where(d => d.Situacao == "PENDENTE")
            .Sum(d => d.Valor);
    }
}