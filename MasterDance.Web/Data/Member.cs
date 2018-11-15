using System.Collections.Generic;

namespace MasterDance.Web.Data
{
    public class Member : IEntity
    {
        public Member()
        {
            Images = new HashSet<Image>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public ICollection<Image> Images { get; }
        public ICollection<Document> Documents { get; }
    }
}