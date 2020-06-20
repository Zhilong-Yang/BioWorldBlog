namespace BioWorld.Application.Post
{
    public class CountPostsDto
    {
        public CountPostsDto(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
