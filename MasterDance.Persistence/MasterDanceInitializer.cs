using MasterDance.Common;
using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MasterDance.Persistence
{
    public class MasterDanceInitializer
    {
        public static void Initialize(MasterDanceDbContext context)
        {
            var initializer = new MasterDanceInitializer();
            initializer.AddDatabaseObjects(context);
            initializer.SeedEverything(context);
        }

        public void AddDatabaseObjects(MasterDanceDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetDebtList')
                BEGIN
                  DROP PROCEDURE GetDebtList
                END
            ");
            context.Database.ExecuteSqlCommand(@"
                CREATE PROCEDURE GetDebtList
                AS
                BEGIN
                    SELECT P.Id, CONCAT(P.FirstName, ' ', P.LastName) AS Member, D.Debt
                    FROM Persons P
                        JOIN
                            (SELECT M.MemberId, M.Amount - ISNULL(P.Amount, 0) AS Debt
                            FROM (SELECT MemberId, SUM(Amount) AS Amount FROM Memberships GROUP BY MemberId) AS M
                            LEFT JOIN (SELECT MemberId, SUM(Payments.Amount) AS Amount FROM Payments JOIN Memberships ON Payments.MembershipId = Memberships.Id GROUP BY MemberId) AS P
                        ON M.MemberId=P.MemberId) AS D ON P.Id=D.MemberId
                END
            ");
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