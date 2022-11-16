using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public Account? Account { get; set; }
        public ICollection<LineItem> LineItems { get; set; } = new HashSet<LineItem>();
        public OrderStatus OrderStatus { get; set; }

    }
}
