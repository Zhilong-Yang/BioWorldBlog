using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class PostPublishEntity : AuditableEntity
    {
        public Guid PostId { get; set; }
        public bool IsPublished { get; set; }
        public bool ExposedToSiteMap { get; set; }
        public bool IsFeedIncluded { get; set; }
        public DateTime? LastModifiedUtc { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? PubDateUtc { get; set; }
        public int? Revision { get; set; }
        public string PublisherIp { get; set; }
        public string ContentLanguageCode { get; set; }

        public PostEntity Post { get; set; }
    }
}