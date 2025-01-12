namespace Generics;

public class IntList
{
    private int[] _items;
    private int _nextIndex;

    public IntList(int capacity)
    {
        _items = new int[capacity];
        _nextIndex = 0;
    }

    public void Add(int item)
    {
        _items[_nextIndex] = item;
        _nextIndex++;
    }

    public int GetItem(int index) => _items[index]; 
} 

public class StringList
{
    private string[] _items;
    private int _nextIndex;

    public StringList(int capacity)
    {
        _items = new string[capacity];
        _nextIndex = 0;
    }

    public void Add(string item)
    {
        _items[_nextIndex] = item;
        _nextIndex++;
    }

    public string GetItem(int index) => _items[index]; 
} 

public class GenericList<T>
{
    private T[] _items;
    private int _nextIndex;

    public GenericList(int capacity)
    {
        _items = new T[capacity];
        _nextIndex = 0;
    }

    public void Add(T item)
    {
        _items[_nextIndex] = item;
        _nextIndex++;
    }

    public T GetItem(int index) => _items[index];  
}