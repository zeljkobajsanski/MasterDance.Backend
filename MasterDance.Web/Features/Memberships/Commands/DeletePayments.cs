using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Memberships.Commands
{
    public class DeletePayments
    {
        public class Input : IRequest<ICollection<MembershipDto>>
        {
            public int MembershipId { get; set; }
        }

        public class Handler : IRequestHandler<Input, ICollection<MembershipDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<ICollection<MembershipDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                var membership = await _context.Memberships.FindAsync(request.MembershipId);
                var payments = _context.Payments.Where(x => x.MembershipId == request.MembershipId);
                _context.Payments.RemoveRange(payments);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberships.Input {MemberId = membership.MemberId}, cancellationToken);
            }
        }
    }
}