using System;

namespace MasterDance.Application.UseCases.Members.Models
{
    public class MembershipModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
    }
}