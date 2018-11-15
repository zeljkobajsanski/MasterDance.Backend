using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Data
{
    public class MasterDanceContext : DbContext
    {
        public MasterDanceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
    }
}