using System;
using System.Collections.Generic;

namespace BioWorld.Application.Post.Queries.GetSegments
{
    public class PostSegmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PubDateUtc { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public int? Revision { get; set; }
        public bool IsPublished { get; set; }
        public int Hits { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class PostSlugSegmentJsonDto
    {
        public IReadOnlyList<PostSegmentDto> PostLists { get; set; }

        public PostSlugSegmentJsonDto(IReadOnlyList<PostSegmentDto> lists)
        {
            PostLists = lists;
        }
    }
}
