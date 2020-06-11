using BioWorld.Domain.Entities;
using BioWorld.Infrastructure.Spec;

namespace BioWorld.Infrastructure.EntitySpec
{
    public sealed class PostTagSpec : BaseSpecification<PostTagEntity>
    {
        public PostTagSpec(int tagId) : base(pt => pt.TagId == tagId
                                                   && !pt.Post.PostPublish.IsDeleted
                                                   && pt.Post.PostPublish.IsPublished)
        {
        }
    }
}