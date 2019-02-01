using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Settings : Entity
    {
        public decimal MembershipAmount { get; set; }
    }
}