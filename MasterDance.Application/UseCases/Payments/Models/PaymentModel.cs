using System;

namespace MasterDance.Application.UseCases.Payments.Models
{
    public class PaymentModel
    {
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public int MemberId { get; set; }
    }
}