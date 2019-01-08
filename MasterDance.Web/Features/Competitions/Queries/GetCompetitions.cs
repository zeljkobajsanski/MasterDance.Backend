using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Competitions.Queries
{
    public class GetCompetitions
    {
        public class Input : IRequest<ICollection<CompetitionDto>> {}
        
        public class Handler : IRequestHandler<Input, ICollection<CompetitionDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<CompetitionDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                return await _context.Competitions.ProjectTo<CompetitionDto>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}