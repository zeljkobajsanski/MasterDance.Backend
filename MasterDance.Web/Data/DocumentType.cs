using System.Collections.Generic;

namespace MasterDance.Web.Data
{
    public class DocumentType : IEntity
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; }
    }
}