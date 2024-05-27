using InsurancePremium.Enums;

namespace InsurancePremium
{
    public class InsurancePremium
    {
        // it's not neccessary to use policyStartDate here, we might just save value here  

        public static (double fullPremium, double proratePremium) CalculatePremium(
            DateTime policyEndDate,
            int employeeAge,
            DateTime employeeJoinDate,
            Gender gender,
            ProrateMethod prorateMethod,
            PricingModel pricingModel)
        {
            double fullPremium = CalculateFullPremium(employeeAge, gender, pricingModel);
            double proratePremium = CalculateProratedPremium(
                fullPremium,
                policyEndDate,
                employeeJoinDate,
                prorateMethod);
            return (fullPremium, proratePremium);
        }

        private static double CalculateFullPremium(int age, Gender gender, PricingModel pricingModel)
        {
            if (pricingModel is PricingModel.FlatRate)
                return 1000;

            double premiumByAge = CalculatePremiumByAge(age);

            if (pricingModel is PricingModel.AgeRated)
            {
                return premiumByAge;
            }

            if (gender is Gender.Male)
            {
                return premiumByAge;
            }
            else
                return age < 18 ? premiumByAge : premiumByAge * 1.5;
        }

        private static double CalculateProratedPremium(
            double fullPremium,
            DateTime policyEndDate,
            DateTime employeeJoinDate,
            ProrateMethod prorateMethod)
        {
            if (prorateMethod is ProrateMethod.ByDays)
            {
                int remainingDays = (policyEndDate - employeeJoinDate).Days;
                return fullPremium / 365 * remainingDays;
            }

            int remainingMonths = (policyEndDate.Year - employeeJoinDate.Year) * 12 + policyEndDate.Month - employeeJoinDate.Month;
            return fullPremium / 12 * remainingMonths;
        }

        private static double CalculatePremiumByAge(int age)
        {
            return age switch
            {
                > 0 and <= 9 => age * 100,
                >= 10 and <= 19 => age * 200,
                >= 20 and <= 29 => age * 300,
                >= 30 and <= 39 => age * 400,
                >= 40 and <= 49 => age * 500,
                >= 50 and <= 59 => age * 600,
                >= 60 and <= 69 => age * 700,
                >= 70 and <= 79 => age * 800,
                >= 80 and <= 89 => age * 900,
                >= 90 and <= 99 => age * 1000,
                _ => age * 1000,
            };
        }


    }
}
