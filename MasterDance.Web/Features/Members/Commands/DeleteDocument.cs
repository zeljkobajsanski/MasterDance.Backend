using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Members.Commands
{
    public class DeleteDocument
    {
        public class Input : IRequest<ICollection<GetDocumentsForMember.Model>>
        {
            public int DocumentId { get; set; }
        }
        
        
        public class Handler : IRequestHandler<Input, ICollection<GetDocumentsForMember.Model>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<ICollection<GetDocumentsForMember.Model>> Handle(Input request, CancellationToken cancellationToken)
            {
                var document = await _context.Documents.FindAsync(request.DocumentId);
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetDocumentsForMember.Query {MemberId = document.MemberId});
            }
        }
    }
}