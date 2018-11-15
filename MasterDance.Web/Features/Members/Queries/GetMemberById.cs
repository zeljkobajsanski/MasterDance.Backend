using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetMemberById
    {
        public class Query : IRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Image { get; set; }
        }
        
        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public QueryHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Members.ProjectTo<Model>(_mapper.ConfigurationProvider)
                                       .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            }
        }
    }
}