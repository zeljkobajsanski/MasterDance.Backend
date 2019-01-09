using System.Linq;
using AutoMapper;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Data.Entities;

namespace MasterDance.Web.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompetitionDto, Competition>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<PrizeDto, Prize>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Membership, MembershipDto>()
                .ForMember(x => x.PaidAmount, opt => opt.MapFrom(x => x.Payments.Sum(p => p.Amount)));
            CreateMap<MemberGroupDto, MemberGroup>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}