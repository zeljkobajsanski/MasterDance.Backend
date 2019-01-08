using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Members.Commands
{
    public class DeletePrize
    {
        public class Input : IRequest<ICollection<PrizeDto>>
        {
            public int MemberId { get; set; }
            public int PrizeId { get; set; }
        }

        public class Handler : IRequestHandler<Input, ICollection<PrizeDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<ICollection<PrizeDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                _context.Prizes.Remove(new Prize() {Id = request.PrizeId});
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberPrizes.Input() {MemberId = request.MemberId});
            }
        }
    }
}