using System;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Evidence : Entity
    {
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Coach Coach { get; set; }
        public int CoachId { get; set; }
    }
}