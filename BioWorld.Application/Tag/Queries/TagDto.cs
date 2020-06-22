using System.Collections.Generic;

namespace BioWorld.Application.Tag.Queries
{
    public class TagDto
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public string NormalizedName { get; set; }
    }

    public class TagJsonDto
    {
        public IReadOnlyList<TagDto> TagList { get; set; }

        public TagJsonDto(IReadOnlyList<TagDto> tagList)
        {
            TagList = tagList;
        }
    }

    public class TagCountInfo : TagDto
    {
        public int TagCount { get; set; }
    }
}