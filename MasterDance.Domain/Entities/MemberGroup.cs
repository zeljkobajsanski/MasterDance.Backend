using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class MemberGroup : Entity
    {
        public string Name { get; set; }
        public ICollection<Member> Members { get; }

        public MemberGroup()
        {
            Members = new List<Member>();
        }
    }
}