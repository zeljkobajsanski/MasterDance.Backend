using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.MemberGroups.Models;
using MasterDance.Application.UseCases.MemberGroups.Queries;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.MemberGroups.Commands
{
    public class SaveMemberGroupCommand
    {
        public class Request : IRequest<ICollection<MemberGroupModel>>
        {
            public Request(MemberGroupModel model)
            {
                Model = model;
            }

            public MemberGroupModel Model { get; }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<MemberGroupModel>>
        {
            private IMediator _mediator;
            public Handler(MasterDanceDbContext dbContext, IMediator mediator) : base(dbContext)
            {
                _mediator = mediator;
            }

            public override async Task<ICollection<MemberGroupModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = new MemberGroup()
                {
                    Id = request.Model.Id,
                    Name = request.Model.Name
                };
                DbContext.MemberGroups.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberGroupsQuery.Request());
            }
        }
    }
}