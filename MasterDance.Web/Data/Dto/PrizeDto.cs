using System;

namespace MasterDance.Web.Data.Dto
{
    public class PrizeDto
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public DateTime? CompetitionDate { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
    }
}