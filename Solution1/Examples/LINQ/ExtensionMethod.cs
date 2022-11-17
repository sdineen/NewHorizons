namespace Examples.LINQ
{
    public static class ExtensionMethod
    {
        public static bool IsPrime(this int i)
        {
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                    return false;
            }
            return true;
        }
    }
}
