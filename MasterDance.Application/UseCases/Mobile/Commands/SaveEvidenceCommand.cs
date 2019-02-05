using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Mobile.Models;
using MasterDance.Common;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Mobile.Commands
{
    public class SaveEvidenceCommand
    {
        public class Request : IRequest<Unit>
        {
            public Request(SaveEvidenceModel model)
            {
                Model = model;
            }

            public SaveEvidenceModel Model { get; }
        }

        public class Handler : RequestHandlerBase<Request, Unit>
        {
            private readonly IDateTime _dateTime;
            public Handler(MasterDanceDbContext dbContext, IDateTime dateTime) : base(dbContext)
            {
                _dateTime = dateTime;
            }

            public override async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                request.Model.Date = _dateTime.Now;

                // New
                await DbContext.Evidences.AddRangeAsync(request.Model.Members.Where(x => !x.EvidenceId.HasValue).Select(x =>
                    new Evidence()
                    {
                        CoachId = request.Model.CoachId,
                        Date = request.Model.Date,
                        MemberId = x.Id
                    }), cancellationToken);
                
                // Existing
                request.Model.Members.Where(x => x.EvidenceId.HasValue && !x.IsSelected).ToList()
                    .ForEach(e =>
                        {
                            DbContext.Database.ExecuteSqlCommand($"DELETE FROM Evidences WHERE Id={e.EvidenceId}");
                        });

                await DbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}