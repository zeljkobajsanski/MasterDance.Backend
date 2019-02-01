using System;
using System.Collections.Generic;
using System.Text;
using MasterDance.Common;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public abstract class MembershipCalculatorBase : IMembershipCalculator
    {
        protected MasterDanceDbContext DbContext;
        protected IDateTime _dateTime;

        protected MembershipCalculatorBase(MasterDanceDbContext dbContext, IDateTime dateTime)
        {
            DbContext = dbContext;
            _dateTime = dateTime;
        }

        public abstract ICollection<Membership> CalculateMembership();
    }
}
