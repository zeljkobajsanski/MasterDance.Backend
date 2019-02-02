using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Exceptions;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Members.Queries
{
    public class GetMemberQuery
    {
        public class Request : IRequest<MemberDetailsModel>
        {
            public Request(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        public class Handler : RequestHandlerBase<Request, MemberDetailsModel>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<MemberDetailsModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var member = await DbContext.Members.FindAsync(request.Id);
                if (member == null) throw new NotFoundException("Members", request.Id);

                return member.ToModel();
            }
        }
    }
}