using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Members.Queries
{
    public class GetMembershipsQuery
    {
        public class Request : IRequest<ICollection<MembershipModel>>
        {
            public Request(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<MembershipModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<MembershipModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Memberships
                    .Where(x => x.MemberId == request.Id)
                    .Select(Projections.ToModel())
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}