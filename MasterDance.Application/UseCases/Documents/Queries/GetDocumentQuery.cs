using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Documents.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Documents.Queries
{
    public class GetDocumentQuery
    {
        public class Request : IRequest<DocumentModel>
        {
            public int Id { get; }

            public Request(int id)
            {
                Id = id;
            }
        }

        public class Handler : RequestHandlerBase<Request, DocumentModel> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<DocumentModel> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Documents.Where(x => x.Id == request.Id)
                    .Select(x => x.ToModel())
                    .SingleOrDefaultAsync(cancellationToken);
            }
        }
    }
}