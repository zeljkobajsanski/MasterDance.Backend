using System;

namespace MasterDance.Web.Data.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public Membership Membership { get; set; }
        public int MembershipId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}