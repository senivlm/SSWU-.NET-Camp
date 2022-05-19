namespace HW1
{
    public static class Check
    {
        public static string GetInfo(Buy buy)
        {
            return $"Product name: {buy.Product.Name}\nUnit price: {buy.Product.Price}\nAmount: {buy.Amount}\nTotal cost: {buy.Price}";
        }
    }
}