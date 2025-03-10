using System;
using System.Collections.Generic;

namespace Datenbank___Database_First_EFC_automatische_generierte_code_;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string? OrderNumber { get; set; }

    public int CustomerId { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
