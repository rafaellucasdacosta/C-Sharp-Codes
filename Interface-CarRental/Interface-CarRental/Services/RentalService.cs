using System;
using Interface_CarRental.Entities;
using Interface_CarRental.Exceptions;

namespace Interface_CarRental.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }       
        public ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            if(pricePerDay <= 0 || pricePerHour <= 0)
            {
                throw new DomainException("The price must be a positive value!");
            }
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            double tax;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);                
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);                
            }
            tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);

        }
    }
}
