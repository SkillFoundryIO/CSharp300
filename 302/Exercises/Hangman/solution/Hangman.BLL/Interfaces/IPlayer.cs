namespace Hangman.BLL.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        string GetGuess();
        int Wins { get; set; }

        IWordSource WordSource { get; set; }
    }
}
