using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.ValueObjects
{
    public class Parent : ValueObject
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Phone;
        }

        public static Parent For(string name = null, string phone = null)
        {
            return new Parent() {Name = name, Phone = phone};
        }
    }
}