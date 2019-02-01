using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Competitions.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Competitions.Queries
{
    public class GetCompetitionsQuery
    {
        public class Request : IRequest<ICollection<CompetitionModel>>
        {
            
        }

        public class Handler : RequestHandlerBase<Request, ICollection<CompetitionModel>>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<CompetitionModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Competitions.Select(x => x.ToModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}