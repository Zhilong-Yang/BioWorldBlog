using System;

namespace BioWorld.Application.Post.Commands.CreatePost
{
    public class CreatePostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string EditorContent { get; set; }
        public bool EnableComment { get; set; }
        public bool IsPublished { get; set; }
        public bool ExposedToSiteMap { get; set; }
        public bool IsFeedIncluded { get; set; }
        public string ContentLanguageCode { get; set; }

        public string[] Tags { get; set; }
        public Guid[] CategoryIds { get; set; }

        public string RequestIp { get; set; }

        public DateTime? PublishDate { get; set; }
    }
}