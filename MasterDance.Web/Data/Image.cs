namespace MasterDance.Web.Data
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}