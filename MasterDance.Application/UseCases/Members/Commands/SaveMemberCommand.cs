using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.Interfaces;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Members.Commands
{
    public class SaveMemberCommand
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
            private readonly IImageService _imageService;
            public Handler(MasterDanceDbContext dbContext, IImageService imageService) : base(dbContext)
            {
                _imageService = imageService;
            }

            public override async Task<MemberDetailsModel> Handle(Request request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request.MemberDetailsModel.Image))
                {
                    request.MemberDetailsModel.Image = _imageService.SaveImageFromStringBase64(request.MemberDetailsModel.Image);
                }
                var entity = request.MemberDetailsModel.ToEntity();
                DbContext.Members.Update(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity.ToModel();
            }
        }
    }
}