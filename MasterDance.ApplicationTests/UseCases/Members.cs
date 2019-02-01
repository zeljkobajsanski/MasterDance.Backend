using System;
using System.Linq;
using System.Threading;
using MasterDance.Application.Interfaces;
using MasterDance.Application.UseCases.Members.Commands;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.ApplicationTests.Helpers;
using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace MasterDance.ApplicationTests.UseCases
{
    public class Members
    {
        private IImageService _mockImageService = Substitute.For<IImageService>();
        [Fact]
        public async void SaveNewMember()
        {
            using (var dbFactory = new DbContextFactory())
            {
                using (var context = dbFactory.GetContext())
                {
                    var member = new MemberDetailsModel
                    {
                        FirstName = "Jovana",
                        LastName = "Bajsanski",
                        Gender = 1,
                        DateOfBirth = new DateTime(2010, 11, 25),
                        ContactAddress = "Preradoviceva 36, Petrovaradin",
                        FatherFirstName = "Zeljko",
                        MotherFirstName = "Ivana",
                        MotherContactPhone = "063 518885"
                    };
                    var actual =
                        await new SaveMemberCommand.Handler(context, _mockImageService).Handle(new SaveMemberCommand.Request(member), CancellationToken.None);
                
                    Assert.NotEqual(0, actual.Id);
                }
            }
        }

        [Fact]
        public async void UpdateMember()
        {
            using (var dbFactory = new DbContextFactory())
            {
                var entity = new Member()
                {
                    FirstName = "Jovana",
                    LastName = "Bajsanski",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2010, 11, 25),
                    Contact = Contact.From("Preradoviceva 36, Petrovaradin"),
                };
                using (var ctx = dbFactory.GetContext())
                {
                    ctx.Members.Add(entity);
                    ctx.SaveChanges();
                }
                
                
                using (var context = dbFactory.GetContext())
                {
                    var member = new MemberDetailsModel
                    {
                        Id = entity.Id,
                        FirstName = "Jovana",
                        LastName = "Bajsanski",
                        Gender = 1,
                        DateOfBirth = new DateTime(2010, 11, 25),
                        ContactAddress = "Preradoviceva 36, Petrovaradin",
                        FatherFirstName = "Zeljko",
                        MotherFirstName = "Ivana",
                        MotherContactPhone = "063 518885"
                    };
                    
                    // Act
                    var actual =
                        await new SaveMemberCommand.Handler(context, _mockImageService).Handle(new SaveMemberCommand.Request(member), CancellationToken.None);
                
                    // Assert
                    Assert.Equal("Zeljko", actual.FatherFirstName);
                    Assert.Equal("Ivana", actual.MotherFirstName);
                    Assert.Equal("063 518885", actual.MotherContactPhone);
                }
            }
        }

        [Fact]
        public async void GetMembers()
        {
            using (var dbFactory = new DbContextFactory())
            {
                // Arrange
                using (var db = dbFactory.GetContext())
                {
                    db.MemberGroups.Add(new MemberGroup() {Id = 1, Name = "Deca"});
                    db.MemberGroups.Add(new MemberGroup() {Id = 2, Name = "Juniori"});
                    db.MemberGroups.Add(new MemberGroup() {Id = 3, Name = "Seniori"});

                    db.Members.Add(new Member()
                    {
                        FirstName = "Jovana",
                        LastName = "Bajsanski",
                        DateOfBirth = new DateTime(2010, 11, 25),
                        MemberGroupId = 2
                    });
                    db.Members.Add(new Member()
                    {
                        FirstName = "Katarina",
                        LastName = "Gucunski",
                        DateOfBirth = new DateTime(2010, 11, 25)
                    });
                    db.SaveChanges();
                }

                using (var db = dbFactory.GetContext())
                {
                    // Act
                    var actual = await new GetMembersQuery.Handler(db).Handle(new GetMembersQuery.Request(), CancellationToken.None);
                    
                    
                    // Assert
                    Assert.Equal(2, actual.Count());
                }
            }
        }
    }
}