using System.Globalization;

namespace AbstractClassesAndMethods.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpanses { get; set; }

        public Individual()
        {

        }

        public Individual(string name, double annualincome, double healthExpanses) : base(name, annualincome)
        {
            HealthExpanses = healthExpanses;
        }

        public override double CalculateTax()
        {
            if(AnnualIncome < 20000.00)
            {
               return AnnualIncome * 0.15 - HealthExpanses * 0.5;
            }
            else
            {
                return AnnualIncome * 0.25 - HealthExpanses * 0.5;
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
