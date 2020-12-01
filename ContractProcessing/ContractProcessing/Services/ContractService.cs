using System;
using System.Collections.Generic;
using System.Text;
using ContractProcessing.Entities;

namespace ContractProcessing.Services
{
    class ContractService
    {
        IOnlinePaymentService _OnlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _OnlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double baseAmount = contract.TotalValue / months;
            double totalAmount;

            for (int i = 0; i < months; i++)
            {
                
                totalAmount = baseAmount + _OnlinePaymentService.Interest(baseAmount, i + 1);
                totalAmount += _OnlinePaymentService.PaymentFee(totalAmount);

                contract.installments.Add(new Installment(contract.Date.AddMonths(i+1), totalAmount)); 
            }

        }
    }
}
