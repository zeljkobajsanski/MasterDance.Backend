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
    public class GetMemberships
    {
        public class Input : IRequest<ICollection<MembershipDto>>
        {
            public int MemberId { get; set; }
        }
        
        public class Handler : IRequestHandler<Input, ICollection<MembershipDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<MembershipDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                return await _context.Memberships.Include(x => x.Payments).Where(x => x.MemberId == request.MemberId)
                    .ProjectTo<MembershipDto>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}