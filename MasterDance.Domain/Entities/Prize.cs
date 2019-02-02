using System.ComponentModel.DataAnnotations;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class Prize : Entity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Competition Competition { get; set; }
        public int CompetitionId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Choreography { get; set; }
    }
}