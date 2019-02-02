using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MasterDance.Common;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public abstract class MembershipCalculatorBase : IMembershipCalculator
    {
        protected MasterDanceDbContext DbContext;

        protected MembershipCalculatorBase(MasterDanceDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task CalculateMembershipAsync(int year, int month);
    }
}
