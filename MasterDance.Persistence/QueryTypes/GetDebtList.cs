namespace MasterDance.Persistence.QueryTypes
{
    public class GetDebtList
    {
        public int Id { get; set; }
        public string Member { get; set; }
        public decimal Debt { get; set; }
        public decimal Amount { get; set; }
        public decimal Diff { get; set; }
    }
}