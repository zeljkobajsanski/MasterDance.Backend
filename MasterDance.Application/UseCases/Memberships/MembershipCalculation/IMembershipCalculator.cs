using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Memberships.MembershipCalculation
{
    public interface IMembershipCalculator
    {
        Task CalculateMembershipAsync(int year, int month);
    }
}