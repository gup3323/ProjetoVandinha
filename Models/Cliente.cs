using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto_Vandinha.Models
{
    public class Cliente
    {
        [Required, MinLength(11), MaxLength(11)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z\\s]+$")]
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        [Range(15, 100)]
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DataNascimento.Year;
                var hojeDataNascimento = hoje.AddYears(-idade);
                if (DataNascimento > hojeDataNascimento)
                {
                    idade--;
                }
                return idade;

            }
        }
        [Required, EmailAddress]
        private string _email;
        [StringLength(80, MinimumLength = 6)]
        public string Email
        {
            get { return this._email; }
            set { this._email = value?.ToLower().Trim(); }
        }
    }
}
