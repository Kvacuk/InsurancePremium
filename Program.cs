using InsurancePremium.Enums;

namespace InsurancePremium
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DateTime employeeJoinDate = new DateTime(2024, 3, 15);
            DateTime policyEndDate = new DateTime(2025, 2, 20);

            try
            {
                var calculatedPremium = InsurancePremiumCalculator.CalculatePremium(
                policyEndDate,
                25,
                employeeJoinDate,
                Gender.Male,
                ProrateMethod.ByMonths,
                PricingModel.AgeRated);

                Console.WriteLine($"Full Premium: {calculatedPremium.fullPremium}");
                Console.WriteLine($"Prorated Premium: {calculatedPremium.proratePremium:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}