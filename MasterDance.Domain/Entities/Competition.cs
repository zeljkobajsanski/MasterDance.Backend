using System;
using System.ComponentModel.DataAnnotations;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.Entities {
    
    public class Competition : Entity
    {
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}