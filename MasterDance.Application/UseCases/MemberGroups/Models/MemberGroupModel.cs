using FluentValidation;

namespace MasterDance.Application.UseCases.MemberGroups.Models
{
    public class MemberGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Validation : AbstractValidator<MemberGroupModel>
    {
        public Validation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}