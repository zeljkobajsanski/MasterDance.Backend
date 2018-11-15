using System;
using System.Linq;

namespace MasterDance.Web.Data
{
    public static class DbInitializer
    {
        public static void SeedDatabase(MasterDanceContext context)
        {
            if (!context.DocumentTypes.Any())
            {
                context.DocumentTypes.Add(new DocumentType() {Name = "Izvod iz maticne knjige rodjenih"});
                context.DocumentTypes.Add(new DocumentType() {Name = "Lekarski pregled"});
                context.SaveChanges();
            }

            if (!context.Members.Any())
            {
                var jovana = new Member() { FirstName = "Jovana", LastName = "Bajsanski" };
                context.Members.Add(jovana);
                context.SaveChanges(); ;
            }

        }
    }
}