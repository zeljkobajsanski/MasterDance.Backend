using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MasterDance.Application.Infrastructure
{
    public class MediatorRequestPlaceholderClass : IRequest<Unit>
    {
        
    }

    public class MediatorHandlerPlaceholderClass : IRequestHandler<MediatorRequestPlaceholderClass, Unit> {
        public Task<Unit> Handle(MediatorRequestPlaceholderClass request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}