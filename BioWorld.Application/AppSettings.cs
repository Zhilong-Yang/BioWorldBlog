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

        // property with getter only will not work.
        public static AppSettings Instance { get; protected set; } = new AppSettings();

        public EditorChoice Editor { get; set; }

        public int PostAbstractWords { get; set; }

        public string TimeZoneUtcOffset { get; set; }
    }
}