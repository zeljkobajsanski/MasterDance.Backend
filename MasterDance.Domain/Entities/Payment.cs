using System;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Payment : Entity
    {
        public Membership Membership { get; set; }
        public int MembershipId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}