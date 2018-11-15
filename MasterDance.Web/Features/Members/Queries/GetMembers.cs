using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

            public QueryHandler(MasterDanceContext context)
            {
                _context = context;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Members.ProjectTo<Model>().ToListAsync(cancellationToken);
            }
        }
    }
}