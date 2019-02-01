using MasterDance.Domain.Infrastructure;
using MasterDance.Domain.ValueObjects;

namespace MasterDance.Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; } = new Contact();
        public Gender Gender { get; set; }
    }
}