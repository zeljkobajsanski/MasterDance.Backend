using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.PaymentCategories.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.PaymentCategories.Queries
{
    public class GetPaymentGroupsQuery
    {
        public class Request : IRequest<ICollection<PaymentCategoryModel>>
        {
            
        }

        public class Handler : RequestHandlerBase<Request, ICollection<PaymentCategoryModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<PaymentCategoryModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.PaymentCategories.Select(x => new PaymentCategoryModel(){Id = x.Id, Name = x.Name})
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}