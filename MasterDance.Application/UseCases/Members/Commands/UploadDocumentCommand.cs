using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.UseCases.Members.Commands
{
    public class UploadDocumentCommand
    {
        public class Request : IRequest<int>
        {
            public Request(DocumentModel documentModel)
            {
                DocumentModel = documentModel;
            }

            public DocumentModel DocumentModel { get; private set; }
        }

        public class Handler : RequestHandlerBase<Request, int>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                var document = request.DocumentModel.ToEntity();
                await DbContext.AddAsync(document, cancellationToken);
                await DbContext.SaveChangesAsync(cancellationToken);
                return document.Id;
            }
        }
    }
}