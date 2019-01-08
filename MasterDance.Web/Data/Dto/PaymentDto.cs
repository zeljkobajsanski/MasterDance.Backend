using System;

namespace MasterDance.Web.Data.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}