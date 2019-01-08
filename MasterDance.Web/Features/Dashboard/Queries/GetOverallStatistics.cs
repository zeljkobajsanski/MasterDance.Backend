using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Dashboard.Queries
{
    public class GetOverallStatistics
    {
        public class Stats
        {
            public int Members { get; set; }
            public decimal Profit { get; set; }
            public decimal Debit { get; set; }
        }
        public class Input : IRequest<Stats> {}
        
        public class Handler : IRequestHandler<Input, Stats>
        {
            private MasterDanceContext _context;

            public Handler(MasterDanceContext context)
            {
                _context = context;
            }

            public async Task<Stats> Handle(Input request, CancellationToken cancellationToken)
            {
                var members = await _context.Members.Where(x => x.IsActive).CountAsync(cancellationToken);
                var profit = await _context.Memberships.SumAsync(x => x.Amount, cancellationToken: cancellationToken);
                var payments = await _context.Payments.SumAsync(x => x.Amount, cancellationToken);
                return new Stats() {Members = members, Profit = profit, Debit = profit - payments};
            }
        }
    }
}