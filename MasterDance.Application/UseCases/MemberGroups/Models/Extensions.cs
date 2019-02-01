using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.MemberGroups.Models
{
    public static class Extensions
    {
        public static MemberGroupModel ToModel(this MemberGroup entity)
        {
            return new MemberGroupModel() {Id = entity.Id, Name = entity.Name};
        }
    }
}