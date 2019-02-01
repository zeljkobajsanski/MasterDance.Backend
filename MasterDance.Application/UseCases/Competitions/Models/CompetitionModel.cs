using System;
using FluentValidation;

namespace MasterDance.Application.UseCases.Competitions.Models
{
    public class CompetitionModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Validation : AbstractValidator<CompetitionModel>
    {
        public Validation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.City).NotEmpty();
        }
    }
}