using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Commands;
using MasterDance.Web.Features.Members.Queries;

namespace MasterDance.Web.Features.Members
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, GetMembers.Model>();
            CreateMap<Member, GetMemberById.Dto>();
            CreateMap<Document, GetDocumentsForMember.Model>();
            CreateMap<Member, GetMemberById.Dto>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (int)x.Gender));
            CreateMap<Member, SaveMember.Dto>().ReverseMap();
        }
    }
}