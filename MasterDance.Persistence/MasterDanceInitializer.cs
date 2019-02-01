namespace MasterDance.Persistence
{
    public class MasterDanceInitializer
    {
        public static void Initialize(MasterDanceDbContext context)
        {
            var initializer = new MasterDanceInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(MasterDanceDbContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}