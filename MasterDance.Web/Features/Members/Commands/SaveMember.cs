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
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Image { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }
        
        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public CommandHandler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var member = _mapper.Map<Member>(request);
                _context.Members.Upsert(member);
                await _context.SaveChangesAsync(cancellationToken);
                return member.Id;
            }
        }
    }
}