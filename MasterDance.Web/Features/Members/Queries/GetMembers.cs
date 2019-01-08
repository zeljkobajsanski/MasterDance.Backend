using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetMembers
    {
        public class Query : IRequest, IRequest<List<Model>>
        {}

        public class Model
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Image { get; set; }
        }
        
        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly MasterDanceContext _context;
            private IMapper _mapper;

            public QueryHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Members.Where(x => x.IsActive).ProjectTo<Model>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}