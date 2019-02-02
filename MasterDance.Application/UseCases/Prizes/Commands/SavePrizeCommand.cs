using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Prizes.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Prizes.Commands
{
    public class SavePrizeCommand
    {
        public class Request : IRequest<PrizeModel>
        {
            public Request(PrizeModel model)
            {
                Model = model;
            }

            public PrizeModel Model { get; }
        }
        
        public class Handler : RequestHandlerBase<Request, PrizeModel> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<PrizeModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = request.Model.ToEntity();
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity.ToModel();
            }
        }
    }
}