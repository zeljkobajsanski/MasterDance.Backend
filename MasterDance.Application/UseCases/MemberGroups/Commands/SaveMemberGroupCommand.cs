using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.MemberGroups.Models;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.MemberGroups.Commands
{
    public class SaveMemberGroupCommand
    {
        public class Request : IRequest<MemberGroupModel>
        {
            public Request(MemberGroupModel model)
            {
                Model = model;
            }

            public MemberGroupModel Model { get; }
        }

        public class Handler : RequestHandlerBase<Request, MemberGroupModel>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<MemberGroupModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = new MemberGroup()
                {
                    Id = request.Model.Id,
                    Name = request.Model.Name
                };
                DbContext.MemberGroups.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity.ToModel();
            }
        }
    }
}