using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Features.MemberGroups.Queries;
using MediatR;

namespace MasterDance.Web.Features.MemberGroups.Commands
{
    public class DeleteGroupById
    {
        public class Input : IRequest<ICollection<MemberGroupDto>>
        {
            public int Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Input, ICollection<MemberGroupDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<ICollection<MemberGroupDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                var group = await _context.MemberGroups.FindAsync(request.Id);
                _context.MemberGroups.Remove(group);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberGroups.Input(), cancellationToken);
            }
        }
    }
}