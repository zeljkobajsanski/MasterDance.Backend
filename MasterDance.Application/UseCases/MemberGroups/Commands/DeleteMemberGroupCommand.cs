using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.MemberGroups.Models;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.MemberGroups.Commands
{
    public class DeleteMemberGroupCommand
    {
        public class Request : IRequest<ICollection<MemberGroupModel>>
        {
            public Request(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<MemberGroupModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<MemberGroupModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                DbContext.Entry(new MemberGroup {Id = request.Id}).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync(cancellationToken);
                return await DbContext.MemberGroups.Select(Projections.ToModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}