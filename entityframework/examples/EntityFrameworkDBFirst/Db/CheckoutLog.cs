using System;
using System.Collections.Generic;

namespace EntityFrameworkDBFirst.Db;

public partial class CheckoutLog
{
    public int CheckoutLogId { get; set; }

    public int BorrowerId { get; set; }

    public int MediaId { get; set; }

    public DateOnly CheckoutDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Borrower Borrower { get; set; } = null!;

    public virtual Medium Media { get; set; } = null!;
}
