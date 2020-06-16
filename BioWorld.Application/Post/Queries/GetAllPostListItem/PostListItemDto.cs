using System;
using System.Collections.Generic;
using BioWorld.Application.Tag.Queries;

namespace BioWorld.Application.Post.Queries.GetAllPostListItem
{
    public class PostListItemDto
    {
        public DateTime PubDateUtc { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string ContentAbstract { get; set; }

        public IList<TagDto> Tags { get; set; }
    }
}