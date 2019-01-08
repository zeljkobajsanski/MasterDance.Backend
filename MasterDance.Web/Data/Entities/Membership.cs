using System;
using System.Collections.Generic;

namespace MasterDance.Web.Data.Entities
{
    public class Membership : IEntity
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Payment> Payments { get; private set; }

        public Membership()
        {
            Payments = new List<Payment>();
        }
    }
}