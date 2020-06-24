using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class ContentSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public string DisharmonyWords { get; set; }

        public bool EnableComments { get; set; }

        public bool RequireCommentReview { get; set; }

        public bool EnableWordFilter { get; set; }

        public bool UseFriendlyNotFoundImage { get; set; }

        public int PostListPageSize { get; set; }

        public int HotTagAmount { get; set; }

        public bool EnableGravatar { get; set; }

        public bool ShowCalloutSection { get; set; }

        public string CalloutSectionHtmlPitch { get; set; }

        public bool ShowPostFooter { get; set; }

        public string PostFooterHtmlPitch { get; set; }
    }
}