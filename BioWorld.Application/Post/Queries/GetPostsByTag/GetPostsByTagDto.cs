using System;

namespace BioWorld.Application.Post.Queries.GetPostsByTag
{
    public class GetPostsByTagDto
    {
        public DateTime PubDateUtc { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string ContentAbstract { get; set; }
    }
}
