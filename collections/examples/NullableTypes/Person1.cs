namespace NullableTypes;

public class Person1
{
    // Use ? to signal the property can be null
    public string? FirstName { get; set; } 
    
    // Omit ? to signal the property should never be null
    public string LastName { get; set; } 
}