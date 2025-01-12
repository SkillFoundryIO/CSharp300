// set up dice rolls and initial counts (0)
Dictionary<int, int> results = new()
{
    {2, 0},
    {3, 0},
    {4, 0},
    {5, 0},
    {6, 0},
    {7, 0},
    {8, 0},
    {9, 0},
    {10, 0},
    {11, 0},
    {12, 0}
};

Random rng = new();
int die1, die2, roll;

for (int i=0; i<100; i++)
{
    die1 = rng.Next(1, 7);
    die2 = rng.Next(1, 7);
    roll = die1 + die2;

    if(results.ContainsKey(roll))
    {
        results[roll]++;
    }
    else
    {
        results.Add(roll, 1);
    }
}

Console.WriteLine("Results");

foreach(var key in results.Keys)
{
    Console.WriteLine($"{key} - {results[key]} ({results[key]/100.00:p0})");
}
