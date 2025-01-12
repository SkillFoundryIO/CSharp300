using Generics;

IntList nums = new(10);

nums.Add(1);
nums.Add(2);
Console.WriteLine(nums.GetItem(0)); // 1


StringList words = new(10);

words.Add("one");
words.Add("two");
Console.WriteLine(words.GetItem(0)); // "one"

GenericList<int> nums2 = new(10);

nums2.Add(1);
nums2.Add(2);

Console.WriteLine(nums2.GetItem(0)); // 1

GenericList<string> words2 = new(10);

words2.Add("one");
words2.Add("two");

Console.WriteLine(words2.GetItem(0)); // "one"

GenericList<Person> people = new(5);

var p1 = new Person { Name="Joe" };
var p2 = new Person { Name="Mary" };

people.Add(p1);
people.Add(p2);

Console.WriteLine(people.GetItem(0).Name); // Joe