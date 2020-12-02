using System;
using System.Collections.Generic;
using ContractProcessing.Exceptions;

namespace ContractProcessing.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract(int number, DateTime date, double totalValue)
        {
            if(totalValue < 0)
            {
                throw new DomainException("The contract value must be positive.");
            }
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }
    }
}
