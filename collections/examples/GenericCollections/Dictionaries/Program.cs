using Dictionaries;

// Creating an empty dictionary
Dictionary<string, MemberInfo> members = new();

// Create a member
MemberInfo newMember = new()
{ 
    MemberID = "0001", 
    MemberName = "John Doe" 
};

// check if the key already exists, then add to the dictionary
if (!members.ContainsKey(newMember.MemberID))
{
    // Add key-value pair, ID and the whole object
    members.Add(newMember.MemberID, newMember);
}

// Access and modify a value using the key
// Changes "John Doe" to "Jane Smith" for key "0001"
members["0001"].MemberName = "Jane Smith";

// Remove an entry by key
// Removes the entire entry for key "0001"
members.Remove("0001");

members.Add(newMember.MemberID, newMember);
members.Add("0002", new MemberInfo { MemberID="0002", MemberName="Jane Smith"});

// Iterate only the keys
foreach (string key in members.Keys)
{
   Console.WriteLine($"Member ID (key): {key}"); 
}

// Iterate the full key-value pairs 
foreach (KeyValuePair<string, MemberInfo> member in members)
{
   Console.WriteLine($"ID: {member.Key}, Name: {member.Value.MemberName}");
}

// var version, much easier to read!
foreach (var member in members)
{
   Console.WriteLine($"ID: {member.Key}, Name: {member.Value.MemberName}");
}


