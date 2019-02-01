using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MasterDance.Application.Infrastructure
{
    public class RequestHandlerLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public RequestHandlerLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public Task Process(TRequest request, TResponse response)
        {
            var name = typeof(TResponse).FullName;
            var content = JsonConvert.SerializeObject(response);
            _logger.LogDebug("Executed command: {Name} with response {@response}", name, content);
            return Task.CompletedTask;
        }
    }
}