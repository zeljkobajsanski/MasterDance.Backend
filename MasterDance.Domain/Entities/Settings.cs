using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Settings : Entity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}