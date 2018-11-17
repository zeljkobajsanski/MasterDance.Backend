using System;

namespace MasterDance.Web.Data.Entities
{
    public class Document : IEntity
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public DocumentType Type { get; set; }
        public int TypeId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Blob Content { get; set; }
    }
}