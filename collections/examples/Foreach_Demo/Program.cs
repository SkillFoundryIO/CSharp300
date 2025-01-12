int[] numbers = [1, 2, 3, 4, 5];

// using indexer
for(int i=0; i<numbers.Length; i++)
{
    Console.WriteLine(i);
}

// using foreach
foreach(int num in numbers)
{
    Console.WriteLine(num);
}