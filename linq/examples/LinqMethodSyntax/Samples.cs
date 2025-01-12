namespace LinqMethodSyntax;

public class Samples
{
    public void LamdaSyntax()
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        IEnumerable<int> evenNumbers = nums.Where(n => n % 2 == 0);
    }

    public void FuncDelegate()
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        // Declare the delegate and assign it to our method
        Func<int, bool> isEvenDelegate = IsEven;

        // Pass the delegate to Where, IsEven method invoked on each element
        IEnumerable<int> evenNumbers = nums.Where(isEvenDelegate);
        Print(evenNumbers);
    }

    // Method that the delegate points to
    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    private void Print(IEnumerable<int> numbers)
    {
        Console.WriteLine($"Filtered List: {string.Join(",", numbers)}");
    }
}
