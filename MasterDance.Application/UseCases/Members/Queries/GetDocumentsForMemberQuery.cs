using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Extensions = MasterDance.Application.UseCases.Documents.Models.Extensions;

namespace MasterDance.Application.UseCases.Members.Queries
{
    public class GetDocumentsForMemberQuery
    {
        public class Request : IRequest<ICollection<DocumentModel>>
        {
            public Request(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<DocumentModel>>
        {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<DocumentModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Documents.Where(x => x.MemberId == request.Id)
                    .Select(Projections.ToDocumentModel()).ToArrayAsync(cancellationToken);
            }
        }
    }
}