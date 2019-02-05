namespace MasterDance.Persistence.QueryTypes
{
    public class Evidence
    {
        public int? EvidenceId { get; set; }
        public int MemberId { get; set; }
        public string Image { get; set; }
        public string MemberName { get; set; }
        public bool IsSelected { get; set; }
    }
}