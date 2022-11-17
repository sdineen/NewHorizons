namespace Examples.DesignPatterns.Decorator2
{
    public class VeblenGood : Product
    {
        public override double RetailPrice
        {
            get
            {
                return CostPrice * 4;
            }
        }
    }
}
