using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterDance.Common;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public class StandardMembershipCalculator : MembershipCalculatorBase
    {
        public StandardMembershipCalculator(MasterDanceDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task CalculateMembershipAsync(int year, int month)
        {
            var members = await DbContext.Members.ToArrayAsync();
            var prices = await DbContext.TrainingTypes.ToDictionaryAsync(x => x.Id);
            
            foreach (var member in members)
            {
                var membershipForDance = await DbContext.Memberships.SingleOrDefaultAsync(x =>
                    x.MemberId == member.Id &&
                    x.Description == prices[Constants.TrainingTypes.Dance].Name &&
                    x.Year == year &&
                    x.Month == month
                );
                if (membershipForDance == null)
                {
                    DbContext.Memberships.Add(new Membership()
                    {
                        Member = member,
                        Year = year,
                        Month = month,
                        Description = prices[Constants.TrainingTypes.Dance].Name,
                        Amount = prices[Constants.TrainingTypes.Dance].Price
                    });
                }

                if (member.Gymnastics)
                {
                    DbContext.Memberships.Add(new Membership()
                    {
                        Member = member,
                        Year = year,
                        Month = month,
                        Description = prices[Constants.TrainingTypes.Gymnastics].Name,
                        Amount = prices[Constants.TrainingTypes.Gymnastics].Price
                    }); 
                }
            }

            await DbContext.SaveChangesAsync();
        }
    }
}