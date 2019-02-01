using System.Collections.Generic;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public interface IMembershipCalculator
    {
        ICollection<Membership> CalculateMembership();
    }
}