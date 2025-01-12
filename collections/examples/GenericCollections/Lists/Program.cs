using Lists;

// empty list with .Add() method
List<string> animals = new();
animals.Add("Zebra");
animals.Add("Elephant");

// Initialization syntax
List<string> colors = ["red", "green", "blue"];

List<Person> people = [
    new Person { FirstName="Joe", LastName="Schmoe" },
    new Person { FirstName="Jane", LastName="Doe" }
];

// empty list []
List<string> colors2 = new();

// Add two elements
colors2.Add("blue");
colors2.Add("green");
//  ["blue", "green"]

// Create an array of colors
string[] rangeOfColors = ["purple", "black", "white", "red"];

// AddRange() adds a collection to the list
colors2.AddRange(rangeOfColors);
// ["blue", "green", "purple", "black", "white", "red"]

// Remove an element by value
colors2.Remove("blue");
// ["green", "purple", "black", "white", "red"]

// Remove by index (black)
colors2.RemoveAt(2);
// ["green", "purple", "white", "red"]

// Using a for loop with index access
for (int i = 0; i < colors2.Count; i++)
{
    Console.WriteLine($"Color at index {i}: {colors2[i]}");
}

// Using foreach (more common when you just need the values)
foreach (string color in colors2)
{
    Console.WriteLine($"Color: {color}");
}