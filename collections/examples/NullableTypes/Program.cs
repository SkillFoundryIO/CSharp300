// illegal, value types cannot be null
// int x = null;

// legal, y is declared as nullable
int? y = null;

// null coalescing operator
int val = y ?? 10;


int? nullableNum = null;
int result = nullableNum.GetValueOrDefault();     // 0
int result2 = nullableNum.GetValueOrDefault(-1);  // -1

Person2 person = new(null, "Smith");

int? nameLength = person.FirstName?.Length;
Console.WriteLine($"{nameLength ?? -1}");

string configValue = ReadFromSettingsFile();
// only assign value if configValue is null
configValue ??= "Default Value";