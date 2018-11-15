using MasterDance.Web.Data;

namespace MasterDance.IntegrationTests
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(MasterDanceContext ctx)
        {
            ctx.Members.Add(new Member() { FirstName = "Jovana", LastName = "Bajsanski" });
            ctx.Members.Add(new Member() { FirstName = "Katarina", LastName = "Gucunski" });
            ctx.SaveChanges();
        }
    }
}