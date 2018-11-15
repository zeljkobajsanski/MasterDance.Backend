using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Documents.Queries
{
    public class GetDocumentTypes
    {
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public class Request : IRequest<IList<Model>>
        {
            
        }
        
        public class RequestHandler : IRequestHandler<Request, IList<Model>>
        {
            private readonly IMapper _mapper;
            private readonly MasterDanceContext _context;

            public RequestHandler(IMapper mapper, MasterDanceContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IList<Model>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await _context.DocumentTypes.ProjectTo<Model>(_mapper.ConfigurationProvider)
                                                   .ToListAsync(cancellationToken);
            }
        }
    }
}