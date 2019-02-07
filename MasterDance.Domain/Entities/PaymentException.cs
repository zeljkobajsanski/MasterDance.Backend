using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class PaymentException : Entity
    {
        public Member Member { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Price { get; set; }
    }
}