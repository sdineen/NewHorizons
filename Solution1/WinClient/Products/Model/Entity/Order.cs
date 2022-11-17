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
        {
            return LineItems.RemoveAll(li => li.Product == product) == 1;
        }
        public override string ToString()
        {
            string text = $"{Environment.NewLine}Order Id: {OrderId}, Date: {Date}, Status: {OrderStatus} {Environment.NewLine}Account Id: {Account.Id}, Account Name: {Account.Name}  {Environment.NewLine}Products: ";
            LineItems.ForEach(lineItem => text += lineItem + ", ");
            return text;
        }

        /*
                 public bool RemoveProduct(Product product, int quantity)
        {
            LineItem lineItem = LineItems.FirstOrDefault(li => li.Product.Id == product.Id);
            if (lineItem == null)
            {
                throw new InvalidOperationException($"{product.Name} is not in Order");
            }
            if (lineItem.Quantity < quantity)
            {
                return false;
            }
            if (lineItem.Quantity >= quantity)
            {
                lineItem.Quantity -= quantity;
            }
            if (lineItem.Quantity == 0)
            {
                LineItems.Remove(lineItem);
            }
            return true;
        }
        */
    }
}
