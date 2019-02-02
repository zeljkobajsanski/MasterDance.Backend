namespace MasterDance.Application.UseCases.Dashboard.Models
{
    public class DebtModel
    {
        public int MemberId { get; set; }
        public string Member { get; set; }
        public decimal Balance { get; set; }
    }
}