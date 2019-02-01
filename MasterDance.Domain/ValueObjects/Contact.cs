using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.ValueObjects
{
    public class Contact : ValueObject
    {
        public string Address { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
            yield return Email;
            yield return Phone;
        }

        public static Contact From(string address = null, string phone = null, string email = null)
        {
            return new Contact(){Address = address, Phone = phone, Email = email};
        }
    }
}