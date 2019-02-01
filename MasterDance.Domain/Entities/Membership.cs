using System;
using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Membership : Entity
    {
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