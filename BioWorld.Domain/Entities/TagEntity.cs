using System.Collections.Generic;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class TagEntity : AuditableEntity
    {
        public TagEntity()
        {
            PostTag = new HashSet<PostTagEntity>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<PostTagEntity> PostTag { get; set; }
    }
}