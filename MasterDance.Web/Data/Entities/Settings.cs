namespace MasterDance.Web.Data.Entities
{
    public class Settings : IEntity
    {
        public int Id { get; set; }
        public decimal MembershipAmount { get; set; }
    }
}