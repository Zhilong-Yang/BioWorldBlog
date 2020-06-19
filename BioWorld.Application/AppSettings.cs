namespace BioWorld.Application
{
    public enum EditorChoice
    {
        None = 0,
        HTML = 1,
        Markdown = 2
    }

    public class AppSettings
    {
        public AppSettings()
        {
        }

        public EditorChoice Editor { get; set; }

        public int PostAbstractWords { get; set; }
    }
}