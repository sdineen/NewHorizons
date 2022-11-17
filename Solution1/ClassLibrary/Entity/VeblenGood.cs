namespace ClassLibrary.Entity
{
    public class VeblenGood : Product
    {
        public VeblenGood()
        {
        }

        public VeblenGood(string id, string name, double costPrice, double retailPrice = 0) : base(id, name, costPrice, retailPrice)
        {
        }

        public override double RetailPrice
        {
            get=> CostPrice * 4;
        }
    }
}
