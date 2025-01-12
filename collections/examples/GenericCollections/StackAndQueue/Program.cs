
Queue<string> line = new();

line.Enqueue("Smith, party of 2");
line.Enqueue("Jones, party of 4");
line.Enqueue("Willis, party of 2");

// Smith, party of 2
Console.WriteLine($"{line.Peek()} is up next!");
// 3 parties
Console.WriteLine($"There are {line.Count} parties in line.");

// Smith, party of 2
Console.WriteLine($"Calling {line.Dequeue()}.");
// 2 parties, Smith was dequeued
Console.WriteLine($"There are {line.Count} parties in line.");

// Jones, party of 4
Console.WriteLine($"{line.Peek()} is up next!");
// 2 parties, Peek() does not remove elements
Console.WriteLine($"There are {line.Count} parties in line.");

// Empty stack []
Stack<string> actions = new();

// Push adds elements to the top of the stack
actions.Push("Edit");   // ["Edit"]
actions.Push("Copy");   // ["Copy", "Edit"]
actions.Push("Paste");  // ["Paste", "Copy", "Edit"]

// Peek looks at top element without removing it
Console.WriteLine(actions.Peek());  // Outputs: "Paste"

// Pop removes and returns the top element
string top = actions.Pop(); 
// top = "Paste", stack is now ["Copy", "Edit"]

// Peek at the new top element
Console.WriteLine(actions.Peek());  // Outputs: "Copy"