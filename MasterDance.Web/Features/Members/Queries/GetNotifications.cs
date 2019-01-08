using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Features.Members.Queries
{
    public class GetNotifications
    {
        public class Notification
        {
            public int MemberId { get; set; }
            public string Member { get; set; }
            public string NotificationType { get; set; }
            public DateTime Date { get; set; }
            public int DaysDiff => (int) Date.Subtract(DateTime.Now).TotalDays;
        }
        public class Input : IRequest<ICollection<Notification>> {}
        
        public class Handler : IRequestHandler<Input, ICollection<Notification>>
        {
            private readonly MasterDanceContext _context;

            public Handler(MasterDanceContext context)
            {
                _context = context;
            }

            public async Task<ICollection<Notification>> Handle(Input request, CancellationToken cancellationToken)
            {
                var now = DateTime.Now.Date;
                return await _context.Documents.Include(x => x.Member).Include(x => x.Type)
                    .Where(x => x.Member.IsActive && x.ExpirationDate.HasValue && x.ExpirationDate.Value.Date.Subtract(now).Days <= 30)
                    .Select(x => new Notification()
                    {
                        MemberId = x.MemberId,
                        Member = $"{x.Member.FirstName} {x.Member.LastName}",
                        Date = x.ExpirationDate.Value,
                        NotificationType = x.Type.Name
                    })
                    .ToArrayAsync(cancellationToken);
            }
        }
    }
}