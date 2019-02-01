using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities
{
    public class DocumentType : Entity
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public string Name { get; set; }
        public ICollection<Document> Documents { get; }
    }
}