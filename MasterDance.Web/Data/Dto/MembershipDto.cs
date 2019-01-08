using System;

namespace MasterDance.Web.Data.Dto
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
    }
}