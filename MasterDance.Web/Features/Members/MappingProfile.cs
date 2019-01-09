using System;
using AutoMapper;
using MasterDance.Web.Data;
using MasterDance.Web.Data.Entities;
using MasterDance.Web.Features.Members.Commands;
using MasterDance.Web.Features.Members.Queries;
using System.Drawing;
using System.IO;
using SixLabors.ImageSharp;
using Image = SixLabors.ImageSharp.Image;

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
            CreateMap<Member, SaveMember.Dto>().ReverseMap()
                .ForMember(x => x.Image, opt => opt.ResolveUsing<ImageResolver>());
        }
    }
    
    public class ImageResolver : IValueResolver<SaveMember.Dto, Member, string>
    {
        public string Resolve(SaveMember.Dto source, Member destination, string destMember, ResolutionContext context)
        {
            if (source.Image != null && source.Image.StartsWith("data:"))
            {
                var ix = source.Image.IndexOf("base64,");
                var image = Image.Load(Convert.FromBase64String(source.Image.Substring(ix + 7)));
                var path = "wwwroot/ProfileImages";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var imageName = $"{Guid.NewGuid()}.png";
                
                image.Save($"{path}/{imageName}");
                return $"/ProfileImages/{imageName}";
            }

            return source.Image;
        }
    }
}