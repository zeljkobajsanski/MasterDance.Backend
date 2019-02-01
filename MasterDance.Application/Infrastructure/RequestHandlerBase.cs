using System.Threading;
using System.Threading.Tasks;
using MasterDance.Persistence;
using MediatR;

namespace MasterDance.Application.Infrastructure
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly MasterDanceDbContext DbContext;

        protected RequestHandlerBase(MasterDanceDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}