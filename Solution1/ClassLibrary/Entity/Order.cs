using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Entity
{
    public class Order 
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Provisional;
        public Account Account { get; set; }
        public String AccountId { get; set; }
        public virtual List<LineItem> LineItems { get; set; } = new List<LineItem>();

        public void AddProduct(Product product, int quantity)
        {
            LineItem lineItem = LineItems.SingleOrDefault(li => li.Product.Id == product.Id);
            if (lineItem == null)
            {
                LineItems.Add(new LineItem(product, quantity));
            }
            else
            {
                lineItem.Quantity += quantity;
            }
        }

        public bool RemoveLineItem(Product product)
            => LineItems.RemoveAll(li => li.Product == product) == 1;
        
        public override string ToString()
        {
            string text = $"{Environment.NewLine}Order Id: {OrderId}, Date: {Date}, Status: {OrderStatus} {Environment.NewLine}Account Id: {Account?.Id}, Account Name: {Account?.Name}  {Environment.NewLine}Products: ";
            LineItems?.ForEach(lineItem => text += lineItem + ", ");
            return text;
        }
    }
}
