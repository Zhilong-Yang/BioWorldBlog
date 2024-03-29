﻿using System;

namespace BioWorld.Application.Post.Queries.GetSegment
{
    public class PostSlugSegmentDto
    {
        public string Title { get; set; }
        public DateTime PubDateUtc { get; set; }
        public DateTime? LastModifyOnUtc { get; set; }
        public string[] Categories { get; set; }
        public string[] Tags { get; set; }
    }
}
