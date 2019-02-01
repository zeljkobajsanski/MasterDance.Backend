using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Competitions.Models;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Competitions.Commands
{
    public class DeleteCompetitionCommand
    {
        public class Request : IRequest<ICollection<CompetitionModel>>
        {
            public Request(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<CompetitionModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<CompetitionModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                DbContext.Entry(new Competition {Id = request.Id}).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync(cancellationToken);
                return await DbContext.Competitions.Select(x => x.ToModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}