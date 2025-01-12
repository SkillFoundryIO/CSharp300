using Hangman.UI;

Console.WriteLine("Welcome to Hangman!");

var game = new App(
    PlayerFactory.CreatePlayer(1), 
    PlayerFactory.CreatePlayer(2)
    );

game.Run();