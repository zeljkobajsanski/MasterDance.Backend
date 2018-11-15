namespace MasterDance.Web.Data.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}