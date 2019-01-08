using System;
using System.Collections.Generic;

namespace MasterDance.Web.Data.Entities
{
    public class Member : Person
    {
        public Member()
        {
            Images = new HashSet<Image>();
            Documents = new HashSet<Document>();
            Prizes = new List<Prize>();
        }

        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? JoinedDate { get; set; }
        public ICollection<Image> Images { get; }
        public ICollection<Document> Documents { get; }
        public int? FatherId { get; set; }
        public Person Father { get; set; }
        public int? MotherId { get; set; }
        public Person Mother { get; set; }
        public ICollection<Prize> Prizes { get; private set; }
        public bool IsActive { get; set; }
    }
}