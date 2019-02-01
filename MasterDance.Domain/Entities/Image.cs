using MasterDance.Domain.Infrastructure;
using MasterDance.Domain.ValueObjects;

namespace MasterDance.Domain.Entities
{
    public class Image : Entity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Blob Blob { get; set; }
    }
}