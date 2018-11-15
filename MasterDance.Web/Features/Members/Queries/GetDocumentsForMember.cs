using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetDocumentsForMember
    {
        public class Model
        {
            public int Id { get; set; }
            public string TypeName { get; set; }
            public DateTime? Date { get; set; }
        }

        public class Query : IRequest<IList<Model>>
        {
            public int MemberId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IList<Model>>
        {
            private readonly MasterDanceContext _context;

            public QueryHandler(MasterDanceContext context)
            {
                _context = context;
            }

            public async Task<IList<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Documents.Include(x => x.Type)
                                     .Where(x => x.MemberId == request.MemberId)
                                     .ProjectTo<Model>()
                                     .ToListAsync(cancellationToken);
            }
        }
    }
}