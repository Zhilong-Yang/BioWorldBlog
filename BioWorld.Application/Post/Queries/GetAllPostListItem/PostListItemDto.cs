﻿using System;
using System.Collections.Generic;
using BioWorld.Application.Tag.Queries;

namespace BioWorld.Application.Post.Queries.GetAllPostListItem
{
    public class PostListItemDto
    {
        public Guid Id { get; set; }

        public DateTime PubDateUtc { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string ContentAbstract { get; set; }

        public IList<TagDto> Tags { get; set; }
    }

    public class PostListItemJsonDto
    {
        public IReadOnlyList<PostListItemDto> PostLists { get; set; }

        public PostListItemJsonDto(IReadOnlyList<PostListItemDto> lists)
        {
            PostLists = lists;
        }
    }
}