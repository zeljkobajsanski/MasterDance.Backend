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
                    SELECT P.Id, CONCAT(P.FirstName, ' ', P.LastName) AS Member, D.Amount, D.Debt, D.Amount - D.Debt Diff
                    FROM Persons P
                        JOIN
                            (SELECT M.MemberId, M.Amount, M.Amount - ISNULL(P.Amount, 0) AS Debt
                            FROM (SELECT MemberId, SUM(Amount) AS Amount FROM Memberships GROUP BY MemberId) AS M
                            LEFT JOIN (SELECT MemberId, SUM(Payments.Amount) AS Amount FROM Payments JOIN Memberships ON Payments.MembershipId = Memberships.Id GROUP BY MemberId) AS P
                        ON M.MemberId=P.MemberId) AS D ON P.Id=D.MemberId
                END
            ");
            context.Database.ExecuteSqlCommand(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetMembershipsAndPayments')
                BEGIN
                  DROP PROCEDURE GetMembershipsAndPayments
                END
            ");
            context.Database.ExecuteSqlCommand(@"
                CREATE PROCEDURE GetMembershipsAndPayments (@MemberId int = NULL)
                AS
                BEGIN
                    SELECT M.Id, CONCAT(PE.FirstName, ' ', PE.LastName) Member, M.Description, M.MemberId, M.Year, M.Month, M.Amount, ISNULL(P.PaidAmount, 0) PaidAmount, M.Amount - ISNULL(P.PaidAmount, 0) Difference
                    FROM Memberships M
                        LEFT JOIN (SELECT MembershipId, SUM(Amount) AS PaidAmount FROM Payments P GROUP BY P.MembershipId) AS P
                            ON M.Id=P.MembershipId
                    JOIN Persons PE ON PE.Id=M.MemberId
                    WHERE (@MemberId IS NULL OR PE.Id=@MemberId)
                END
                ");

            context.Database.ExecuteSqlCommand(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEvidence')
                BEGIN
                  DROP PROCEDURE GetEvidence
                END
            ");
            context.Database.ExecuteSqlCommand(@"
                CREATE PROCEDURE GetEvidence (@Date date, @CoachId int, @MemberGroupId int = NULL)
                AS
                BEGIN
                    SELECT E.Id EvidenceId, P.Id MemberId, CONCAT(P.FirstName, ' ', P.LastName) MemberName, P.Image, CAST(CASE WHEN E.Id IS NULL THEN 0 ELSE 1 END AS BIT) IsSelected
                    FROM Persons P
                        LEFT JOIN Evidences E
                            ON E.MemberId = P.Id
                    WHERE P.MemberType='Member' AND (E.Date IS NULL OR E.Date = @Date) AND 
                         (E.CoachId IS NULL OR E.CoachId = @CoachId) AND (@MemberGroupId IS NULL OR P.MemberGroupId = @MemberGroupId)
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
                context.DocumentTypes.Add(new DocumentType() { Name = "Diploma" });
                context.DocumentTypes.Add(new DocumentType() { Name = "Slika" });
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

            if (!context.MemberGroups.Any())
            {
                context.MemberGroups.Add(new MemberGroup() {Name = "Grbavica - Bebe"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Grbavica - Početna"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Grbavica - Deca"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Grbavica - Pčelice"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Grbavica - Juniori"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Srbobran - Pčelice"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Srbobran - Juniori"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Tesla - I Razred"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Tesla - II Razred"});
                context.MemberGroups.Add(new MemberGroup() {Name = "Klisa - Deca"});
                context.SaveChanges();
            }

            if (!context.PaymentCategories.Any())
            {
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Oslobođen plaćanja"});
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Redovna članarina", Price = 2500});
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Juniori", Price = 3000});
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Srbobran", Price = 1500});
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Klisa", Price = 2000});
                context.PaymentCategories.Add(new PaymentCategory() {Name = "Tesla", Price = 1800});
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

            if (!context.Users.Any())
            {
                context.Users.Add(new User()
                {
                    Email = "zeljko.bajsanski@bitseverywhere.rs",
                    Password = "passw0rd",
                    IsActive = true,
                    Role = "Administrator",
                    Person = new Person()
                    {
                        FirstName = "Zeljko",
                        LastName = "Bajsanski",
                    }
                });
                context.Users.Add(new User()
                {
                    Email = "d.demic@hotmail.com",
                    Password = "1234",
                    IsActive = true,
                    Role = "Administrator",
                    Person = new Person()
                    {
                        FirstName = "Duca",
                        LastName = "Jovanović",
                    }
                });
                context.SaveChanges();
            }
        }
    }
}