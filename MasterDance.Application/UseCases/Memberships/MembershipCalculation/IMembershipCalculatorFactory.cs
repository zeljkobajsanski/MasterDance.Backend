namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public interface IMembershipCalculatorFactory
    {
        IMembershipCalculator GetCalculator();
    }
}