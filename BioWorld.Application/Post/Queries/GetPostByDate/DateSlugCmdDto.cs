namespace BioWorld.Application.Post.Queries.GetPostByDate
{
    public class DateSlugCmdDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Slug { get; set; }
    }
}
