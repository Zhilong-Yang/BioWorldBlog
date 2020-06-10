using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class PostExtensionEntity : AuditableEntity
    {
        public Guid PostId { get; set; }
        public int Hits { get; set; }
        public int Likes { get; set; }

        public virtual PostEntity Post { get; set; }
    }
}