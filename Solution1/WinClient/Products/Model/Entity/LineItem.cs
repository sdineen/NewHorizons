using System;

namespace ClassLibrary.Entity
{
    [Serializable]
    public class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }

        public LineItem()
        {

        }
        public LineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return Quantity + " x " + Product;
        }

        public override bool Equals(object obj)
        {
            LineItem lineItem = obj as LineItem;
            return lineItem == null ? false : 
                lineItem.Id == Id && lineItem.Quantity == Quantity;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Quantity.GetHashCode() * 3 + Product.GetHashCode() * 5;
        }
    }
}
