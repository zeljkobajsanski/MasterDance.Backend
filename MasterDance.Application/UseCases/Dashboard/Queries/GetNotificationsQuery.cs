using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Dashboard.Models;
using MasterDance.Common;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Dashboard.Queries
{
    public class GetNotificationsQuery
    {
        public class Request : IRequest<ICollection<NotificationModel>> {}

        public class Handler : RequestHandlerBase<Request, ICollection<NotificationModel>>
        {
            private readonly IDateTime _dateTime;
            
            public Handler(MasterDanceDbContext dbContext, IDateTime dateTime) : base(dbContext)
            {
                _dateTime = dateTime;
            }

            public override async Task<ICollection<NotificationModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                var now = _dateTime.Now.Date;
                return await DbContext.Documents.Where(x => x.ExpirationDate.HasValue && 
                                (x.ExpirationDate.Value.Date <= now || x.ExpirationDate.Value.Date.Subtract(now).TotalDays <= 30))
                    .Select(
                        x => new NotificationModel()
                        {
                            NotificationType = x.Type.Name,
                            MemberId = x.MemberId,
                            Member = x.Member.FirstName + " " + x.Member.LastName,
                            Date = x.ExpirationDate.Value,
                            DaysDiff = (int) x.ExpirationDate.Value.Date.Subtract(now).TotalDays
                        }
                    ).ToArrayAsync(cancellationToken);
            }
        }
    }
}