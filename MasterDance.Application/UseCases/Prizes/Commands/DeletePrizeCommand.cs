using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Prizes.Models;
using MasterDance.Application.UseCases.Prizes.Queries;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Prizes.Commands
{
    public class DeletePrizeCommand
    {
        public class Request : IRequest<ICollection<PrizeModel>>
        {
            public Request(int id, int memberId)
            {
                Id = id;
                MemberId = memberId;
            }

            public int Id { get; }
            public int MemberId { get; }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<PrizeModel>>
        {
            private readonly IMediator _mediator;
            
            public Handler(MasterDanceDbContext dbContext, IMediator mediator) : base(dbContext)
            {
                _mediator = mediator;
            }

            public override async Task<ICollection<PrizeModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                DbContext.Entry(new Prize {Id = request.Id}).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetPrizesQuery.Request(request.MemberId));
            }
        }
    }
}