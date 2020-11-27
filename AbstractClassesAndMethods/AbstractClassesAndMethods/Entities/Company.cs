using System.Globalization;

namespace AbstractClassesAndMethods.Entities
{
    class Company : TaxPayer
    {
        public int Employees { get; set; }

        public Company()
        {

        }

        public Company(string name, double annualIncome, int employees) : base(name, annualIncome)
        {
            Employees = employees;
        }

        public override double CalculateTax()
        {
            if(Employees > 10)
            {
                return AnnualIncome * 0.14;
            }
            else
            {
               return AnnualIncome * 0.16;
            }
        }

        public override string ToString()
        {
            return Name
                + ": $ "
                + CalculateTax().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
