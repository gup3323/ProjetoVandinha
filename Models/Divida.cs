using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto_Vandinha.Models
{

    //Valor
    //Situação: paga ou não
    //Data de criação
    //Data de pagamento
    //Regra: um cliente só pode ter uma dívida em aberto

    public class Divida
    {
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public bool Situacao { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataPagamento { get; set; }


    }
}
