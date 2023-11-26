using LINQPracticeMinis;

var repository = new DataRepository(@"data\luchadores.csv");
var luchadores = repository.Load();

// proof the data is loading
foreach (var luchador in luchadores)
{
    Console.WriteLine($"{luchador.Alias} - {luchador.FirstName} {luchador.LastName}");
}
