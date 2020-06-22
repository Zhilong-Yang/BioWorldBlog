using System;

namespace BioWorld.Application.Post.Queries.GetArchiveList
{
    public class ArchiveDto
    {
        public Guid PostId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }

        public ArchiveDto(int year, int month, Guid postId, int count)
        {
            Year = year;
            Month = month;
            Count = count;
            PostId = postId;
        }
    }
}