using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MasterDance.Application.Interfaces;
using MasterDance.Application.UseCases.Payments.Commands;
using MasterDance.Application.UseCases.Payments.Models;
using MasterDance.ApplicationTests.Helpers;
using MasterDance.Domain.Entities;
using MasterDance.Persistence.Queries;
using MasterDance.Persistence.QueryTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace MasterDance.ApplicationTests.UseCases
{
    public class Payments
    {
        private IDatabaseQueries _mockQueries = Substitute.For<IDatabaseQueries>();
        
        [Fact]
        public async void AddPayment()
        {
            var payment = new PaymentModel
            {
                MemberId = 1,
                Amount = 3000,
                DateTime = DateTime.Now
            };
            _mockQueries.GetMembershipsAndPayments(1)
                .Returns(new List<MembershipsAndPayments>()
                {
                    new MembershipsAndPayments(){Id = 1, Year = 2018, Month = 12, Amount = 2800, Difference = 2800,},
                    new MembershipsAndPayments(){Id = 2, Year = 2019, Month = 1, Amount = 2800, Difference = 2800},
                    new MembershipsAndPayments(){Id = 3, Year = 2019, Month = 1, Amount = 200, Difference = 200}
                });
            
            using (var dbFactory = new DbContextFactory())
            {
                using (var ctx = dbFactory.GetContext())
                {
                    ctx.Members.Add(new Member()
                    {
                        Id = 1, FirstName = "Jovana", LastName = "Bajsanski", 
                        Gender = Gender.Female,
                        DateOfBirth = new DateTime(2010, 11, 25)
                    });
                    ctx.Memberships.Add(new Membership() {Id = 1, Year = 2018, Month = 12, Amount = 2800, Date = DateTime.Now, MemberId = 1});
                    ctx.Memberships.Add(new Membership() {Id = 2, Year = 2019, Month = 1, Amount = 2800, Date = DateTime.Now, MemberId = 1});
                    ctx.Memberships.Add(new Membership() {Id = 3, Year = 2019, Month = 1, Amount = 200, Date = DateTime.Now, MemberId = 1});
                    ctx.SaveChanges();
                }
                
                // Act
                using (var ctx = dbFactory.GetContext())
                {
                    var mediator = Substitute.For<IMediator>();
                    var command = new AddPaymentCommand.Handler(ctx, _mockQueries, mediator);
                    await command.Handle(new AddPaymentCommand.Request() {Payment = payment}, CancellationToken.None);
                }
                
                // Assert

                using (var ctx = dbFactory.GetContext())
                {
                    var memberships = ctx.Memberships.Include(x => x.Payments).ToDictionary(x => x.Id);
                    
                    Assert.Equal(1, memberships[1].Payments.Count);
                    Assert.Equal(2800, memberships[1].Payments.Single().Amount);
                    
                    Assert.Equal(0, memberships[2].Payments.Count);
                    
                    Assert.Equal(1, memberships[3].Payments.Count);
                    Assert.Equal(200, memberships[3].Payments.Single().Amount);
                }
            }
            
        }
    }
}