﻿using System;
using System.Collections.Generic;
using BioWorld.Application.Category;
using BioWorld.Application.Tag.Queries;

namespace BioWorld.Application.Post.Queries.GetPostListItem
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string RawPostContent { get; set; }
        public bool CommentEnabled { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public string ContentAbstract { get; set; }
        public bool IsPublished { get; set; }
        public bool ExposedToSiteMap { get; set; }
        public bool FeedIncluded { get; set; }
        public string ContentLanguageCode { get; set; }
        public IList<TagDto> Tags { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public DateTime? PubDateUtc { get; set; }
    }
}