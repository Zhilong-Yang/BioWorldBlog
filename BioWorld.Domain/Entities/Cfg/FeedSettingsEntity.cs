using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class FeedSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public int RssItemCount { get; set; }
        public string RssCopyright { get; set; }
        public string RssDescription { get; set; }
        public string RssGeneratorName { get; set; }
        public string RssTitle { get; set; }
        public string AuthorName { get; set; }
        public bool UseFullContent { get; set; }
    }
}