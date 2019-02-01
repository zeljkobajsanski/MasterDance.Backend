using System;
using MasterDance.Domain.Infrastructure;
using MasterDance.Domain.ValueObjects;

namespace MasterDance.Domain.Entities
{
    public class Document : Entity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public DocumentType Type { get; set; }
        public int TypeId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Blob Content { get; set; }
    }
}