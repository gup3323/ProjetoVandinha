using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Vandinha.Models
{
    public class Divida
    {
        [Key]
        public int id_divida { get; set; }

        [Required]
        public string CpfCliente { get; set; } = string.Empty;

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public string Situacao { get; set; } = "PENDENTE";

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        [ForeignKey(nameof(CpfCliente))]
        public Cliente? Cliente { get; set; }
    }
}