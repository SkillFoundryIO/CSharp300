namespace EntityFrameworkDBFirst.Db;

public partial class Borrower
{
    public string NameLastFirst => $"{LastName}, {FirstName}";
}