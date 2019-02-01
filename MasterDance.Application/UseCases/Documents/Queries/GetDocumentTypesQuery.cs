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
    public class GetDocumentTypesQuery
    {
        public class Request : IRequest<ICollection<DocumentTypeModel>> { }
        public class Handler : RequestHandlerBase<Request, ICollection<DocumentTypeModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<DocumentTypeModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.DocumentTypes
                    .Select(x => x.ToModel())
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}