using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Data.Entities
{
    [Owned]
    public class Contact
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}