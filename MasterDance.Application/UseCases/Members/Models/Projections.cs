using System;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Members.Models
{
    public static class Projections
    {
        public static Func<Member, MemberModel> ToMemberModel()
        {
            return m => new MemberModel()
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Image = m.Image,
                MemberGroupId = m.MemberGroupId
            };
        }
    }
}