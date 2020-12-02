using System;
using ContractProcessing.Exceptions;
using ContractProcessing.Entities;

namespace ContractProcessing.Services
{
    class ContractService
    {
        public IOnlinePaymentService OnlinePaymentService { get; set; }

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            OnlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            if(months <= 0)
            {
                throw new DomainException("Number of installments must be highter than zero.");
            }

            DateTime dueDate;
            double amount;
            double baseQuota = contract.TotalValue / months;            

            for (int i = 1; i <= months; i++)
            {
                dueDate = contract.Date.AddMonths(i);
                amount = baseQuota + OnlinePaymentService.Interest(baseQuota, i);
                amount += OnlinePaymentService.PaymentFee(amount);

                contract.Installments.Add(new Installment(dueDate, amount));
            }

        }
    }
}
