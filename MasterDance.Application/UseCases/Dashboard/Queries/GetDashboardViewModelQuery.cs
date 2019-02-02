using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Dashboard.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Dashboard.Queries
{
    public class GetDashboardViewModelQuery
    {
        public class Request : IRequest<DashboardViewModel>
        {
            
        }
        
        public class Handler : RequestHandlerBase<Request, DashboardViewModel> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<DashboardViewModel> Handle(Request request, CancellationToken cancellationToken)
            {
                var totalMembers = await DbContext.Members.CountAsync(cancellationToken);
                var memberships = await DbContext.Memberships.SumAsync(x => x.Amount, cancellationToken);
                var payments = await DbContext.Payments.SumAsync(x => x.Amount, cancellationToken);
                return new DashboardViewModel()
                {
                    TotalMembers = totalMembers,
                    Profit = memberships,
                    Debit = memberships - payments
                };
            }
        }
    }
}