using System;
using System.Collections.Generic;

namespace BioWorld.Application.Post.Queries.GetPostsByTag
{
    public class GetPostsByTagDto
    {
        public DateTime PubDateUtc { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string ContentAbstract { get; set; }
    }

    public class GetPostsByTagJsonDto
    {
        public IReadOnlyList<GetPostsByTagDto> PostList { get; set; }

        public GetPostsByTagJsonDto(IReadOnlyList<GetPostsByTagDto> postList)
        {
            PostList = postList;
        }
    }
}
