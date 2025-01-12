using System;
using System.Collections.Generic;

namespace EntityFrameworkDBFirst.Db;

public partial class Borrower
{
    public int BorrowerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<CheckoutLog> CheckoutLogs { get; set; } = new List<CheckoutLog>();
}
