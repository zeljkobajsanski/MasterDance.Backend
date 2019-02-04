using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IMEI { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}