using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Persistence;
using MasterDance.Persistence.Queries;
using MasterDance.Persistence.QueryTypes;
using MediatR;

namespace MasterDance.Application.UseCases.Memberships.Queries
{
    public class GetMembershipsQuery
    {
        public class Request : IRequest<List<MembershipsAndPayments>> {}
        
        public class Handler : RequestHandlerBase<Request, List<MembershipsAndPayments>>
        {
            private readonly IDatabaseQueries _queries;
            
            public Handler(MasterDanceDbContext dbContext, IDatabaseQueries queries) : base(dbContext)
            {
                _queries = queries;
            }

            public override Task<List<MembershipsAndPayments>> Handle(Request request, CancellationToken cancellationToken)
            {
                var memberships = _queries.GetMembershipsAndPayments(null).ToList();
                return Task.FromResult(memberships);
            }
        }
    }
}