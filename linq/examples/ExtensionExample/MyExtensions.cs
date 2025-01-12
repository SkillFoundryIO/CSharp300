namespace ExtensionExample;
public static class MyExtensions
{
    // The "this" keyword on the first parameter attaches the method to the int type
    public static bool IsOdd(this int i)
    {
        return i % 2 != 0;
    }

    // We can extend any class
    public static int GetArea(this Rectangle r)
    {
        return r.Length * r.Width;
    }

    // We can pass any number of params after the extended param.
    public static string RemoveSpaces(this string s, string replacement)
    {
        return s.Replace(" ", replacement);
    }
}

public class Rectangle(int length, int width)
{
    public int Length { get; set; } = length;
    public int Width { get; set; } = width;
}