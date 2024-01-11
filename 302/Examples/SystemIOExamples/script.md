# Demo: System.IO

New C# Project. Pre-create FileExamples.cs and DirectoryExamples.cs

## Part 1 - Reading, Exists(), Using() and @

Create Data directory

Create text file IceCreamFlavors.txt

```
Vanilla
Chocolate
Strawberry
Mint Chocolate Chip
Rocky Road
Butter Pecan
Cookie Dough
Pistachio
Neapolitan
Cookies and Cream
Salted Caramel
```

Show "copy if newer" property in visual studio

Build the application and demonstrate that the file is in the .bin

Add method 

```c#
private const string ICE_CREAM_PATH = @"Data\IceCreamFlavors.txt";

public static void IceCreamFlavorList()
{
    string path = "Data\\IceCreamFlavors.txt";
    
    if (File.Exists(path))
    {
        string[] flavors = File.ReadAllLines(path);
        Console.WriteLine("Ice Cream Flavors:");
        foreach (var flavor in flavors)
        {
            Console.WriteLine(flavor);
        }
    }
    else
    {
        Console.WriteLine("File not found.");
    }
}
```

Show leading @ symbol trick for file paths

Show that slashes don't matter, I prefer the unix style.

Discuss File.Exists