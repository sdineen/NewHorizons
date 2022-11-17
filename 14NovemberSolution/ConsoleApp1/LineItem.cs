namespace ConsoleApp1
{
    public class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; } //association ("has a")
        public int ProductId { get; set; } //foreign key property
    }
}