using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class LineItems
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
