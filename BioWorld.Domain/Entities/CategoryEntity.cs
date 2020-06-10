using System;
using System.Collections.Generic;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class CategoryEntity : AuditableEntity
    {
        public CategoryEntity()
        {
            PostCategory = new HashSet<PostCategoryEntity>();
        }

        public Guid Id { get; set; }
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }

        public ICollection<PostCategoryEntity> PostCategory { get; set; }
    }
}