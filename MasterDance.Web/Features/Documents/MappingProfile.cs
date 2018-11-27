using System;
using AutoMapper;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Documents.Queries;

namespace MasterDance.Web.Features.Documents
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Document, GetDocumentById.Output>()
                .ForMember(x => x.FileName, opt => opt.MapFrom(x => x.Content.FileName))
                .ForMember(x => x.ContentType, opt => opt.MapFrom(x => x.Content.ContentType))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content.Content));
        }
    }
}