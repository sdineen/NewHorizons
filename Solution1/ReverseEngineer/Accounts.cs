using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class Accounts
    {
        public Accounts()
        {
            Orders = new HashSet<Orders>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
