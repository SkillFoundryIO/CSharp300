using System;
using System.Collections.Generic;

namespace EntityFrameworkDBFirst.Db;

public partial class Medium
{
    public int MediaId { get; set; }

    public int MediaTypeId { get; set; }

    public string Title { get; set; } = null!;

    public bool IsArchived { get; set; }

    public virtual ICollection<CheckoutLog> CheckoutLogs { get; set; } = new List<CheckoutLog>();

    public virtual MediaType MediaType { get; set; } = null!;
}
