using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.Application.UseCases.Payments.Models;
using MasterDance.Common;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MasterDance.Persistence.Queries;
using MediatR;

namespace MasterDance.Application.UseCases.Payments.Commands
{
    public class AddPaymentCommand
    {
        public class Request : IRequest<ICollection<MembershipModel>>
        {
            public int Creator { get; set; }
            public PaymentModel Payment { get; set; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<MembershipModel>>
        {
            private readonly IDatabaseQueries _databaseQueries;
            private readonly IMediator _mediator;
            
            public Handler(MasterDanceDbContext dbContext, IDatabaseQueries databaseQueries, IMediator mediator) : base(dbContext)
            {
                _databaseQueries = databaseQueries;
                _mediator = mediator;
            }

            public override async Task<ICollection<MembershipModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                var list = _databaseQueries.GetMembershipsAndPayments(request.Payment.MemberId)
                    .Where(x => x.Difference > 0).OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Amount);

                var amount = request.Payment.Amount;
                foreach (var item in list)
                {
                    if (amount <= 0) break;
                    var amountToPay = amount > item.Difference ? item.Difference : amount;
                    await DbContext.Payments.AddAsync(new Payment()
                    {
                        MembershipId = item.Id,
                        Amount = amountToPay,
                        Date = request.Payment.DateTime,
                        CreatorId = request.Creator
                    }, cancellationToken);
                    amount -= amountToPay;
                }

                await DbContext.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMembershipsQuery.Request(request.Payment.MemberId), cancellationToken);
            }
        }
    }
}