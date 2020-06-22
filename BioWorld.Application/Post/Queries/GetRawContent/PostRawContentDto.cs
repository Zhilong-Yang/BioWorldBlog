namespace BioWorld.Application.Post.Queries.GetRawContent
{
    public class PostRawContentDto
    {
        public string RawContent { get; set; }

        public PostRawContentDto(string rawContent)
        {
            RawContent = rawContent;
        }
    }
}
