using System;
using Interface_CarRental.Exceptions;

namespace Interface_CarRental.Entities
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; private set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            if(finish < start)
            {
                throw new DomainException("Return date must be after pickup date!");
            }
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}
