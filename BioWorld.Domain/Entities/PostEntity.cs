using System;
using System.Collections.Generic;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class PostEntity : AuditableEntity
    {
        public PostEntity()
        {
            Comment = new HashSet<CommentEntity>();
            PostCategory = new HashSet<PostCategoryEntity>();
            PostTag = new HashSet<PostTagEntity>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string PostContent { get; set; }
        public bool CommentEnabled { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public string ContentAbstract { get; set; }

        public PostExtensionEntity PostExtension { get; set; }
        public PostPublishEntity PostPublish { get; set; }
        public ICollection<CommentEntity> Comment { get; set; }
        public ICollection<PostCategoryEntity> PostCategory { get; set; }
        public ICollection<PostTagEntity> PostTag { get; set; }
    }
}