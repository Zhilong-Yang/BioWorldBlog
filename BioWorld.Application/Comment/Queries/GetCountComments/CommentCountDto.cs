namespace BioWorld.Application.Comment.Queries.GetCountComments
{
    public class CommentCountDto
    {
        public int CommentCount { get; set; }

        public CommentCountDto(int commentCount)
        {
            CommentCount = commentCount;
        }
    }
}
