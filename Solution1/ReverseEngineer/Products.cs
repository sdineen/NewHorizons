using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class Products
    {
        public Products()
        {
            LineItems = new HashSet<LineItems>();
        }

        public string Id { get; set; }
        public double CostPrice { get; set; }
        public bool? IsDiscontinued { get; set; }
        public string Name { get; set; }
        public double RetailPrice { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<LineItems> LineItems { get; set; }
    }
}
