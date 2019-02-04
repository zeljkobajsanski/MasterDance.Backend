using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Mobile.Models;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Mobile.Queries
{
    public class GetMembersForEvidenceQuery
    {
        public class Request : IRequest<ICollection<MemberModel>>
        {
            public int GroupId { get; set; }
            public DateTime Date { get; set; }
        }
        
        public class Handler : RequestHandlerBase<Request, ICollection<MemberModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<MemberModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await DbContext.Members.Where(x => x.MemberGroupId == request.GroupId).Select(x => new MemberModel()
                {
                    Id = x.Id,
                    Image = x.Image,
                    Name = x.FirstName + " " + x.LastName
                }).ToArrayAsync(cancellationToken);
            }
        }
    }
}