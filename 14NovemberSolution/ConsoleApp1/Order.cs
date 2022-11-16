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
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
        public OrderStatus OrderStatus { get; set; }

    }
}
