using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterDance.Web.Data.Entities
{
    public class MemberGroup : IEntity
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public ICollection<Member> Members { get; }

        public MemberGroup()
        {
            Members = new List<Member>();
        }
    }
}