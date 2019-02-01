using System;
using System.Collections.Generic;
using MasterDance.Domain.ValueObjects;

namespace MasterDance.Domain.Entities
{
    public class Member : Person
    {
        public Member()
        {
            Images = new HashSet<Image>();
            Documents = new HashSet<Document>();
            Prizes = new List<Prize>();
            Father = Parent.For();
            Mother = Parent.For();
        }

        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? JoinedDate { get; set; }
        public ICollection<Image> Images { get; }
        public ICollection<Document> Documents { get; }
        public Parent Father { get; set; }
        public Parent Mother { get; set; }
        public ICollection<Prize> Prizes { get; private set; }
        public bool IsActive { get; set; }
        public MemberGroup MemberGroup { get; set; }
        public int? MemberGroupId { get; set; }
        public bool Dance { get; set; }
        public bool Gymnastics { get; set; }
    }
}