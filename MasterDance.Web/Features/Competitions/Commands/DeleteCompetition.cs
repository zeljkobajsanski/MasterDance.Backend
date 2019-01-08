using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Competitions.Queries;
using MediatR;

namespace MasterDance.Web.Features.Competitions.Commands
{
    public class DeleteCompetition
    {
        public class Input : IRequest<ICollection<CompetitionDto>>
        {
            public int Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Input, ICollection<CompetitionDto>>
        {
            private readonly MasterDanceContext _context;
            private readonly IMediator _mediator;

            public Handler(MasterDanceContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<ICollection<CompetitionDto>> Handle(Input request, CancellationToken cancellationToken)
            {
                _context.Competitions.Remove(new Competition() {Id = request.Id});
                await _context.SaveChangesAsync(cancellationToken);

                return await _mediator.Send(new GetCompetitions.Input(), cancellationToken);
            }
        }
    }
}