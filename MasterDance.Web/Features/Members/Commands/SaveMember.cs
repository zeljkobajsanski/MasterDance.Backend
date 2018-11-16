using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;
using MediatR;

namespace MasterDance.Web.Features.Members.Commands
{
    public class SaveMember
    {
        public class Dto : IRequest<int>
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
        
        public class CommandHandler : IRequestHandler<Dto, int>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public CommandHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(Dto request, CancellationToken cancellationToken)
            {
                var member = _mapper.Map<Member>(request);
                _context.Members.Upsert(member);
                await _context.SaveChangesAsync(cancellationToken);
                return member.Id;
            }
        }
    }
}