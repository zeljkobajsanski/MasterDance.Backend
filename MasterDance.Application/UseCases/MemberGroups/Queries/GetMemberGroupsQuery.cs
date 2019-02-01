using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.MemberGroups.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.MemberGroups.Queries
{
    public class GetMemberGroupsQuery
    {
        public class Request : IRequest<ICollection<MemberGroupModel>>
        {
            
        }

        public class Handler : RequestHandlerBase<Request, ICollection<MemberGroupModel>>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<MemberGroupModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.MemberGroups.Select(Projections.ToModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}