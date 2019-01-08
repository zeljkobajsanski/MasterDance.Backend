using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Members.Commands
{
    public class SavePrize
    {
        public class Input : IRequest<ICollection<PrizeDto>>
        {
            public PrizeDto PrizeDto { get; set; }
        }

        public class Handler : IRequestHandler<Input, ICollection<PrizeDto>>
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

            public async Task<ICollection<PrizeDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                Prize prize;
                if (request.PrizeDto.Id == 0)
                {
                    prize = new Prize();
                    _context.Prizes.Add(prize);
                }
                else
                {
                    prize = await _context.Prizes.FindAsync(request.PrizeDto.Id);
                }

                _mapper.Map(request.PrizeDto, prize);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberPrizes.Input(){MemberId = request.PrizeDto.MemberId});
            }
        }
    }
}