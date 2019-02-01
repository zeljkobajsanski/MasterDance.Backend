using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Members.Commands
{
    public class SaveMember
    {
        public class Request : IRequest<MemberDetailsModel>
        {
            public Request(MemberDetailsModel memberDetailsModel)
            {
                MemberDetailsModel = memberDetailsModel;
            }

            public MemberDetailsModel MemberDetailsModel { get; private set; }
        }
        
        public class Handler : RequestHandlerBase<Request, MemberDetailsModel>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<MemberDetailsModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = request.MemberDetailsModel.ToEntity();
                DbContext.Members.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity.ToModel();
            }
        }
    }
}