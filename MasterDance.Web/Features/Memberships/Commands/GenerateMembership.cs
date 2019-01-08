using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;
using MediatR;

namespace MasterDance.Web.Features.Memberships.Commands
{
    public class GenerateMembership
    {
        public class Input : IRequest {}
        
        public class Handler : IRequestHandler<Input>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Input request, CancellationToken cancellationToken)
            {
                var settings = _context.Settings.Single();
                var memberships = _context.Members.Where(x => x.IsActive).Select(x => new Membership
                {
                    Member = x,
                    Date = DateTime.Now,
                    Amount = settings.MembershipAmount
                });
                await _context.Memberships.AddRangeAsync(memberships, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;;
            }
        }
    }
}