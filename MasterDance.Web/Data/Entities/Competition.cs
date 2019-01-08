using System;
using System.ComponentModel.DataAnnotations;

namespace MasterDance.Web.Data.Entities {
    
    public class Competition : IEntity
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string City { get; set; }
    }
}