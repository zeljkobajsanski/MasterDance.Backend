using System;
using System.Linq.Expressions;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.MemberGroups.Models
{
    public static class Projections
    {
        public static Expression<Func<MemberGroup, MemberGroupModel>> ToModel()
        {
            return x => new MemberGroupModel() {Id = x.Id, Name = x.Name};
        }
    }
}