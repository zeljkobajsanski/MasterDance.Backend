using System;
using System.Collections.Generic;

namespace MasterDance.Application.UseCases.Mobile.Models
{
    public class SaveEvidenceModel
    {
        public int CoachId { get; set; }
        public DateTime Date { get; set; }
        public List<EvidenceModel> Members { get; set; }
    }
}