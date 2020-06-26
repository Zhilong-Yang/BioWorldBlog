using System;

namespace BioWorld.Application.Setting.Queries.GetFeedSetting
{
    public class FeedSettingsDto
    {
        public Guid Id { get; set; }

        public int RssItemCount { get; set; }

        public string RssCopyright { get; set; }

        public string RssDescription { get; set; }

        public string RssTitle { get; set; }

        public string AuthorName { get; set; }

        public bool UseFullContent { get; set; }
    }
}
