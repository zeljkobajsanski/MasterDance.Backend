using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetMemberPrizes
    {
        public class Input : IRequest<ICollection<PrizeDto>>
        {
            public int MemberId { get; set; }
        }
        
        public class Handler : IRequestHandler<Input, ICollection<PrizeDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<PrizeDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                var prizes = await _context.Prizes.Include(x => x.Competition)
                    .Where(x => x.MemberId == request.MemberId)
                    .ProjectTo<PrizeDto>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);
                return prizes;
            }
        }
    }
}