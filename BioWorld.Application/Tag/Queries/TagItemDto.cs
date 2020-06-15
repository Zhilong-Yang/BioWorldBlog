using AutoMapper;
using BioWorld.Application.Common.Mappings;
using BioWorld.Domain.Entities;

namespace BioWorld.Application.Tag.Queries
{
    public class TagItemDto : IMapFrom<TagEntity>
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public string NormalizedName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TagEntity, TagItemDto>()
                .ForMember(d => d.TagName,
                    opt => opt.MapFrom(s => s.DisplayName));
        }
    }

    public class TagCountInfo : TagItemDto
    {
        public int TagCount { get; set; }
    }
}