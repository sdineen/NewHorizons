using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class Orders
    {
        public Orders()
        {
            LineItems = new HashSet<LineItems>();
        }

        public int OrderId { get; set; }
        public string AccountId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatus { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ICollection<LineItems> LineItems { get; set; }
    }
}
