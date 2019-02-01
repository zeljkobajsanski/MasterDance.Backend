using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Members.Queries
{
    public class GetMembers
    {
        public class Request : IRequest<IEnumerable<MemberModel>> {}
        
        public class Handler : RequestHandlerBase<Request, IEnumerable<MemberModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<IEnumerable<MemberModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return DbContext.Members.Select(Projections.ToMemberModel()).ToArray();
            }
        }
    }
}