using System.Collections.Generic;
using System.Linq;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public class StandardMembershipCalculator : MembershipCalculatorBase
    {
        public StandardMembershipCalculator(MasterDanceDbContext dbContext) : base(dbContext)
        {
        }

        public override ICollection<Membership> CalculateMembership()
        {
            var members = DbContext.Members.ToArray();
            foreach (var member in members)
            {
                
            }
            throw new System.NotImplementedException();
        }
    }
}