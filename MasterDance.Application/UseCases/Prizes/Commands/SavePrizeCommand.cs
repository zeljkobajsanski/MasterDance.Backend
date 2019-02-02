using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Prizes.Models;
using MasterDance.Application.UseCases.Prizes.Queries;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Prizes.Commands
{
    public class SavePrizeCommand
    {
        public class Request : IRequest<ICollection<PrizeModel>>
        {
            public Request(PrizeModel model)
            {
                Model = model;
            }

            public PrizeModel Model { get; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<PrizeModel>>
        {
            private IMediator _mediator;
            
            public Handler(MasterDanceDbContext dbContext, IMediator mediator) : base(dbContext)
            {
                _mediator = mediator;
            }

            public override async Task<ICollection<PrizeModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = request.Model.ToEntity();
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetPrizesQuery.Request(request.Model.MemberId));
            }
        }
    }
}