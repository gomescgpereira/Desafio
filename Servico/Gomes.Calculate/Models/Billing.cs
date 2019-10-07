using System;

namespace Gomes.Calculate.Models
{
    public class Billing
    {
        public string Cpf { get; set; }
        public DateTime Vencimento { get;  set; }
        public decimal Valor {get; set; }
    }
}