using System;
using System.IO;
using FluentValidation;
using Newtonsoft.Json;

namespace MasterDance.Application.UseCases.Members.Models
{
    public class MemberDetailsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public int? MemberGroupId { get; set; }
        public bool AttendGymnastics { get; set; }
    }

    public class MemberDetailsValidation : AbstractValidator<MemberDetailsModel>
    {
        public MemberDetailsValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotNull();
        }
    }
}