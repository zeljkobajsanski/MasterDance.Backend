using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Documents.Queries
{
    public class GetDocumentById
    {
        public class Input : IRequest<Output>
        {
            public int DocumentId { get; set; }
        }

        public class Output
        {
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public string Content { get; set; }
        }

        public class RequestHandler : IRequestHandler<Input, Output>
        {
            private readonly IMapper _mapper;
            private readonly MasterDanceContext _context;

            public RequestHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Output> Handle(Input input, CancellationToken cancellationToken)
            {
                var document = await _context.Documents.FindAsync(input.DocumentId);
                return _mapper.Map<Output>(document);
            }
        }
    }
}