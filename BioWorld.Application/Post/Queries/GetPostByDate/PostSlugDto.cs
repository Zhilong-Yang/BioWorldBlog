using System;
using System.Collections.Generic;
using BioWorld.Application.Category;
using BioWorld.Application.Tag.Queries;

namespace BioWorld.Application.Post.Queries.GetPostByDate
{
    public class PostSlugDto
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime PubDateUtc { get; set; }
        public DateTime? LastModifyOnUtc { get; set; }
        public string Content { get; set; }
        public int Hits { get; set; }
        public int Likes { get; set; }
        public Guid PostId { get; set; }
        public bool CommentEnabled { get; set; }
        public int CommentCount { get; set; }
        public bool IsExposedToSiteMap { get; set; }

        public IList<CategoryDto> Categories { get; set; }
        public IList<TagDto> Tags { get; set; }
    }

    public class PostSlugJsonDto
    {
        public IReadOnlyList<PostSlugDto> PostSlugList { get; set; }

        public PostSlugJsonDto(IReadOnlyList<PostSlugDto> postSlugList)
        {
            PostSlugList = postSlugList;
        }
    }
}
