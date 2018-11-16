using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MasterDance.Web.Features.Members.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetMemberById
    {
        public class Request : IRequest<Dto>
        {
            public int Id { get; set; }
        }

        public class Dto : SaveMember.Dto
        {
           
        }
        
        public class QueryHandler : IRequestHandler<Request, Dto>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public QueryHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public Task<Dto> Handle(Request request, CancellationToken cancellationToken)
            {
                return _context.Members.ProjectTo<Dto>(_mapper.ConfigurationProvider)
                                       .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            }
        }
    }
}