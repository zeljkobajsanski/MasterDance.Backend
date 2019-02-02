using System;
using FluentValidation;

namespace MasterDance.Application.UseCases.Prizes.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public DateTime? CompetitionDate { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Choreography { get; set; }
    }

    public class Validation : AbstractValidator<PrizeModel>
    {
        public Validation()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}