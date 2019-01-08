using System;

namespace MasterDance.Web.Data.Dto
{
    public class CompetitionDto
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}