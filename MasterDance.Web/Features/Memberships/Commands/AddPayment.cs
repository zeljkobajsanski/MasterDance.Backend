using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Memberships.Commands
{
    public class AddPayment
    {
        public class Input : IRequest<ICollection<MembershipDto>>
        {
            public int MembershipId { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
        }

        public class Handler : IRequestHandler<Input, ICollection<MembershipDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }

            public async Task<ICollection<MembershipDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                var membership = await _context.Memberships.FindAsync(request.MembershipId);
                _context.Payments.Add(new Payment()
                {
                    Membership = membership,
                    Date = request.Date,
                    Amount = request.Amount
                });
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberships.Input() {MemberId = membership.MemberId});
            }
        }
    }
}