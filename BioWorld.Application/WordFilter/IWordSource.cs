namespace BioWorld.Application.WordFilter
{
    public interface IWordSource
    {
        char SplitChar { get; }

        string[] GetWordsArray();
    }
}
