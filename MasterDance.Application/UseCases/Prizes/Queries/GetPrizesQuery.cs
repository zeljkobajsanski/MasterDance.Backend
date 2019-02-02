using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Prizes.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Prizes.Queries
{
    public class GetPrizesQuery
    {
        public class Request : IRequest<ICollection<PrizeModel>>
        {
            public Request(int memberId)
            {
                MemberId = memberId;
            }

            public int MemberId { get; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<PrizeModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<PrizeModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Prizes.Select(x => x.ToModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}