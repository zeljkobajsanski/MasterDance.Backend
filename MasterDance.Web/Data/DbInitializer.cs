using System;
using System.Linq;
using MasterDance.Web.Data.Entities;

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

            if (!context.Settings.Any())
            {
                context.Settings.Add(new Settings() {MembershipAmount = 2500});
                context.SaveChanges();
            }
        }
    }
}