using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Memberships.MembershipCalculation;
using MasterDance.Common;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Memberships.Commands
{
    public class CalculateMembershipCommand
    {
        public class Request : IRequest<Unit>
        {
            public Request(int year, int month)
            {
                Year = year;
                Month = month;
            }

            public int Year { get; }
            public int Month { get; }
        }
        public class Handler : RequestHandlerBase<Request, Unit>
        {
            private readonly IMembershipCalculatorFactory _membershipCalculatorFactory;
            public Handler(MasterDanceDbContext dbContext, IMembershipCalculatorFactory membershipCalculatorFactory) : base(dbContext)
            {
                _membershipCalculatorFactory = membershipCalculatorFactory;
            }

            public override async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                IMembershipCalculator membershipCalculator =  _membershipCalculatorFactory.GetCalculator();
                await membershipCalculator.CalculateMembershipAsync(request.Year, request.Month);
                return Unit.Value;
            }
        }
    }
}