using System.Linq;

namespace MasterDance.Web.Data
{
    public static class DbInitializer
    {
        public static void SeedDatabase(MasterDanceContext context)
        {
            if (!context.Members.Any())
            {
                context.Members.Add(new Member() {FirstName = "Jovana", LastName = "Bajsanski"});
                context.SaveChanges();;
            }

            if (!context.DocumentTypes.Any())
            {
                context.DocumentTypes.Add(new DocumentType() {Name = "Izvod iz maticne knjige rodjenih"});
                context.DocumentTypes.Add(new DocumentType() {Name = "Lekarski pregled"});
                context.SaveChanges();
            }
        }
    }
}