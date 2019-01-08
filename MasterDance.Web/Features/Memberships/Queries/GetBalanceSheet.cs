using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Memberships.Queries
{
    public class GetBalanceSheet
    {
        public class BalanceSheetItem
        {
            public int MemberId { get; set; }
            public string Member { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal TotalPaid { get; set; }
            public decimal Balance => TotalPaid - TotalAmount;
        }
        
        public class Input : IRequest<ICollection<BalanceSheetItem>> {}
        
        public class Handler : IRequestHandler<Input, ICollection<BalanceSheetItem>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<BalanceSheetItem>> Handle(Input request, CancellationToken cancellationToken)
            {
                return await _context.Memberships.Include(x => x.Member).Include(x => x.Payments)
                    .GroupBy(x => x.Member)
                    .Select(x => new BalanceSheetItem()
                    {
                        MemberId = x.Key.Id,
                        Member = $"{x.Key.FirstName} {x.Key.LastName}",
                        TotalAmount = x.Sum(y => y.Amount),
                        TotalPaid = x.Sum(y => y.Payments.Sum(z => z.Amount))
                    })
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}