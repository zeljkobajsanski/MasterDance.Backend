using System;
using System.Linq;
using System.Reflection;
using MasterDance.Common;
using MasterDance.Persistence;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public class MembershipCalculatorFactory : IMembershipCalculatorFactory
    {
        private readonly MasterDanceDbContext _dbContext;

        public MembershipCalculatorFactory(MasterDanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMembershipCalculator GetCalculator()
        {
            var calculatorType = _dbContext.Settings.Single(x => x.Key == Constants.SettingsKey.MembershipCalculator).Value;
            return (IMembershipCalculator)Activator.CreateInstance(Type.GetType(calculatorType), new Object[]{_dbContext});
        }
    }
}