using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_CarRental.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
