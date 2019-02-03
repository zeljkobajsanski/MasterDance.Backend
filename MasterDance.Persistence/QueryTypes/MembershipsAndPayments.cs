namespace MasterDance.Persistence.QueryTypes
{
    public class MembershipsAndPayments
    {
        public int Id { get; set; }
        public string Member { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Difference { get; set; }
    }
}