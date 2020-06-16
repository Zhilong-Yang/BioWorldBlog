using BioWorld.Domain.Entities;

namespace BioWorld.Application.Tag.Queries
{
    public class TagDto
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public string NormalizedName { get; set; }
    }

    public class TagCountInfo : TagDto
    {
        public int TagCount { get; set; }
    }
}