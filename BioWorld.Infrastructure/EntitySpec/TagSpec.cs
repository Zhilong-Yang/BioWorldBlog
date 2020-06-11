using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public sealed class TagSpec : BaseSpecification<TagEntity>
    {
        public TagSpec(int top) : base(t => true)
        {
            ApplyPaging(0, top);
            ApplyOrderByDescending(p => p.PostTag.Count);
        }

        public TagSpec(string normalizedName) : base(t => t.NormalizedName == normalizedName)
        {
        }
    }
}