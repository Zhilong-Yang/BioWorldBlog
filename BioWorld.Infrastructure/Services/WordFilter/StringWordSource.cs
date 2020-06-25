namespace BioWorld.Infrastructure.Services.WordFilter
{
    public class StringWordSource
    {
        public char SplitChar { get; }

        public string Words { get; }

        public StringWordSource(string words, char splitChar = '|')
        {
            Words = words;
            SplitChar = splitChar;
        }

        public string[] GetWordsArray()
        {
            return Words.Split(SplitChar);
        }
    }
}