using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class PostCategoryEntity : AuditableEntity
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
        public PostEntity Post { get; set; }
    }
}