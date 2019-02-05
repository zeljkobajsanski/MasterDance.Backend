using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MasterDance.Application.Infrastructure;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Mobile.Commands
{
    public class RegisterDeviceCommand
    {
        public class Request : IRequest<Unit>
        {
            public string DeviceId { get; set; }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.DeviceId).NotEmpty();
            }
        }

        public class Handler : RequestHandlerBase<Request, Unit> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var account = await DbContext.Users.SingleOrDefaultAsync(x => x.UUID == request.DeviceId, cancellationToken);
                if (account == null)
                {
                    await DbContext.Users.AddAsync(new User(){UUID = request.DeviceId}, cancellationToken);
                    await DbContext.SaveChangesAsync(cancellationToken);
                }
                return Unit.Value;
            }
        }
    }
}