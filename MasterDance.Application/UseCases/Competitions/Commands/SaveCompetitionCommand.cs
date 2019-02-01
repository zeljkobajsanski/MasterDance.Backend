using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Competitions.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Competitions.Commands
{
    public class SaveCompetitionCommand
    {
        public class Request : IRequest<int>
        {
            public Request(CompetitionModel model)
            {
                Model = model;
            }

            public CompetitionModel Model { get; }
        }

        public class Handler : RequestHandlerBase<Request, int>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = request.Model.ToEntity();
                DbContext.Competitions.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}