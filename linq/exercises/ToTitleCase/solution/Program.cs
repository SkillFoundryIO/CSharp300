using ToTitleCase;

Console.Write("Enter a sentence: ");
string input = Console.ReadLine();

string result = input.ToTitleCase();  // Result: "Hello World"

Console.WriteLine($"\"{result}\" is the input in title case.");
