using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Features.Members.Queries;

namespace MasterDance.Web.Features.Members
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, GetMembers.Model>();
            CreateMap<Member, GetMemberById.Model>();
            CreateMap<Document, GetDocumentsForMember.Model>();
        }
    }
}