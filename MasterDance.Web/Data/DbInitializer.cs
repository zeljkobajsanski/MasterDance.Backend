using System.Linq;

namespace MasterDance.Web.Data
{
    public static class DbInitializer
    {
        public static void SeedDatabase(MasterDanceContext context)
        {
            if (context.Members.Any())
            {
                return;
            }

            context.Members.Add(new Member() {FirstName = "Jovana", LastName = "Bajsanski"});
            context.SaveChanges();
        }
    }
}