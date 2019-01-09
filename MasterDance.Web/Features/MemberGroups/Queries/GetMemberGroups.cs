using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.MemberGroups.Queries
{
    public class GetMemberGroups
    {
        public class Input : IRequest<ICollection<MemberGroupDto>>
        {
        }
        
        public class Handler : IRequestHandler<Input, ICollection<MemberGroupDto>> {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<MemberGroupDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                return await _context.MemberGroups.ProjectTo<MemberGroupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}