using System.ComponentModel.DataAnnotations;

namespace MasterDance.Web.Data.Entities
{
    public class Prize : IEntity
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Competition Competition { get; set; }
        public int CompetitionId { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
    }
}