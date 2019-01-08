using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Queries;
using MediatR;

namespace MasterDance.Web.Features.Members.Commands
{
    public class SaveMember
    {
        public class Dto : IRequest<GetMemberById.Dto>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Gender { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public DateTime? JoinedDate { get; set; }
            public string Image { get; set; }
            public string ContactAddress { get; set; }
            public string ContactPhone { get; set; }
            public int? FatherId { get; set; }
            public int? MotherId { get; set; }
            public string FatherFirstName { get; set; }
            public string FatherContactPhone { get; set; }
            public string MotherFirstName { get; set; }
            public string MotherContactPhone { get; set; }
            public bool IsActive { get; set; }
        }

        public class DtoValidator : AbstractValidator<Dto>
        {
            public DtoValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.DateOfBirth).NotEmpty();
                RuleFor(x => x.Gender).GreaterThan(0);
            }
        }
        
        public class CommandHandler : IRequestHandler<Dto, GetMemberById.Dto>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public CommandHandler(MasterDanceContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }

            public async Task<GetMemberById.Dto> Handle(Dto request, CancellationToken cancellationToken)
            {
                var member = _mapper.Map<Member>(request);
                if (member.Father != null && string.IsNullOrEmpty(member.Father.FirstName))
                {
                    member.Father = null;
                }
                if (member.Mother != null && string.IsNullOrEmpty(member.Mother.FirstName))
                {
                    member.Mother = null;
                }
                _context.Members.Upsert(member);
                await _context.SaveChangesAsync(cancellationToken);
                return await _mediator.Send(new GetMemberById.Request(){Id = member.Id}, cancellationToken);
            }
        }
    }
}