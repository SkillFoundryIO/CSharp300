using ExtensionExample;

int x = 5;

// using the extension method
if (x.IsOdd())
{
    Console.WriteLine($"{x} is odd");
}

var r = new Rectangle(10, 20);
Console.WriteLine(r.GetArea());

// Extensions also impact literals
var noSpaces = "This is a sentence.".RemoveSpaces("_");
Console.WriteLine(noSpaces); // This_is_a_sentence