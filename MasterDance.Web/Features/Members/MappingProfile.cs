using AutoMapper;
using MasterDance.Web.Data;

namespace MasterDance.Web.Features.Members
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, Features.Members.GetMembers.Model>();
            CreateMap<Member, Features.Members.GetMemberById.Model>();
        }
    }
}