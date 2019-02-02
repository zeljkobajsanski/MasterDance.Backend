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
    public class GetDebtList
    {
        public class Request : IRequest<ICollection<DebtModel>> {}
        
        public class Handler : RequestHandlerBase<Request, ICollection<DebtModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<DebtModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return (await DbContext.GetDebtList.FromSql("EXECUTE GetDebtList").ToArrayAsync(cancellationToken))
                    .Select(x => new DebtModel()
                    {
                        MemberId = x.Id,
                        Member = x.Member,
                        Balance = x.Debt
                    }).ToArray();
            }
        }
    }
}