using EntityFrameworkDBFirst.Db;

var context = new LibraryManagerContext();

foreach(var b in context.Borrowers.ToList())
{
    Console.WriteLine(b.NameLastFirst);
}