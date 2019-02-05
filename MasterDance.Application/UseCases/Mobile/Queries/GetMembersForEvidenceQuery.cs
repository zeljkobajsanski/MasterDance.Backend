using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Mobile.Models;
using MasterDance.Persistence;
using MasterDance.Persistence.QueryTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Mobile.Queries
{
    public class GetMembersForEvidenceQuery
    {
        public class Request : IRequest<ICollection<EvidenceModel>>
        {
            public int GroupId { get; set; }
            public DateTime Date { get; set; }
            public int CoachId { get; set; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<EvidenceModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<EvidenceModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                Evidence[] result = await DbContext.EvidencesQuery
                    .FromSql(
                        $"EXECUTE GetEvidence @Date = {request.Date}, @CoachId = {request.CoachId}, @MemberGroupId = {request.GroupId}")
                    .ToArrayAsync(cancellationToken);

                return result.Select(x => new EvidenceModel()
                {
                    Id = x.MemberId,
                    Name = x.MemberName,
                    Image = x.Image,
                    IsSelected = x.IsSelected,
                    EvidenceId = x.EvidenceId
                }).ToList();
            }
        }
    }
}