using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MediatR;

namespace MasterDance.Web.Features.Competitions.Commands
{
    public class SaveCompetition
    {
        public class Input : IRequest<int>
        {
            public CompetitionDto CompetitionDto { get; set; }
        }
        
        public class Handler : IRequestHandler<Input, int>
        {
            private readonly MasterDanceContext _context;
            private readonly IMapper _mapper;

            public Handler(MasterDanceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(Input request, CancellationToken cancellationToken)
            {
                Competition competition;

                if (request.CompetitionDto.Id == 0)
                {
                    competition = new Competition();
                    _context.Competitions.Add(competition);
                }
                else
                {
                    competition = await _context.Competitions.FindAsync(request.CompetitionDto.Id);
                }

                _mapper.Map(request.CompetitionDto, competition);
                await _context.SaveChangesAsync(cancellationToken);
                return competition.Id;
            }
        }
    }
}