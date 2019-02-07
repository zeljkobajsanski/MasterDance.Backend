using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class PaymentCategory : Entity
    {
        public PaymentCategory()
        {
            Members = new List<Member>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Member> Members { get; private set; }
    }
}