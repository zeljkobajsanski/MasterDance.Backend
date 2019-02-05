namespace MasterDance.Application.UseCases.Mobile.Models
{
    public class EvidenceModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public int? EvidenceId { get; set; }
    }
}