using MasterDance.Common;
using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;

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
            if (!context.DocumentTypes.Any())
            {
                context.DocumentTypes.Add(new DocumentType() { Name = "Izvod iz maticne knjige rodjenih" });
                context.DocumentTypes.Add(new DocumentType() { Name = "Lekarski pregled" });
                context.SaveChanges();
            }

            if (!context.Settings.Any())
            {
                context.Settings.Add(new Settings()
                {
                    Key = Constants.SettingsKey.MembershipCalculator,
                    Value = "MasterDance.Application.UseCases.Memberships.MembershipCalculation.StandardMembershipCalculator"
                });
                context.SaveChanges();
            }

            if (!context.TrainingTypes.Any())
            {
                context.TrainingTypes.Add(new TrainingType()
                    {Id = Constants.TrainingTypes.Dance, Name = "Ples", Price = 2800});
                context.TrainingTypes.Add(new TrainingType()
                    { Id = Constants.TrainingTypes.Gymnastics, Name = "Gimnastika", Price = 200 });
                context.SaveChanges();
            }
        }
    }
}