using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.MemberGroups.Queries;
using MediatR;

namespace MasterDance.Web.Features.MemberGroups.Commands
{
    public class SaveMemberGroup
    {
        public class Input : IRequest<ICollection<MemberGroupDto>>
        {
            public MemberGroupDto MemberGroupDto { get; set; }
        }

        public class Handler : IRequestHandler<Input, ICollection<MemberGroupDto>>
        {
            private MasterDanceContext _context;
            private IMediator _mediator;
            private IMapper _mapper;

            public Handler(MasterDanceContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<ICollection<MemberGroupDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                MemberGroup memberGroup;
                if (request.MemberGroupDto.Id == 0)
                {
                    memberGroup = new MemberGroup();
                    await _context.MemberGroups.AddAsync(memberGroup, cancellationToken);
                }
                else
                {
                    memberGroup = await _context.MemberGroups.FindAsync(request.MemberGroupDto.Id);
                }

                _mapper.Map(request.MemberGroupDto, memberGroup);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberGroups.Input(), cancellationToken);
            }
        }
    }
}