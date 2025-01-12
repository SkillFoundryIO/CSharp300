using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class DictionarySource : IWordSource
    {
        public string GetWord()
        {
            Random rng = new Random();
            string[] words = File.ReadLines(@"data\dictionary.txt").ToArray();

            return words[rng.Next(0, words.Length)].ToUpper();
        }
    }
}
