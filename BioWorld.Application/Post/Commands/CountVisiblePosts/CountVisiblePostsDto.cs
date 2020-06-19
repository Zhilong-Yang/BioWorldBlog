using System;

namespace BioWorld.Application.Post.Commands.CountVisiblePosts
{
    public class CountVisiblePostsDto
    {
        public CountVisiblePostsDto(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
