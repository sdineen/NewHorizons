namespace ClassLibrary.Entity
{
    public class NormalGood : Product
    {
        public NormalGood()
        {

        }
        public NormalGood(string id, string name, double costPrice)
            : base(id, name, costPrice, 0)
        {

        }
        public override double RetailPrice
        {
            get
            {
                return CostPrice * 2;
            }
        }
    }
}
