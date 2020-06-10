using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class PostTagEntity : AuditableEntity
    {
        public Guid PostId { get; set; }
        public int TagId { get; set; }

        public PostEntity Post { get; set; }
        public TagEntity Tag { get; set; }
    }
}