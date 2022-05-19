namespace HW1
{
    public class Buy
    {
        public Product Product { get; }
        public int Amount { get; }
        public double Price { get; }
        public double Weight { get; }

        public Buy(Product product, int amount)
        {
            Product = product;
            Amount = amount;
            Price = Product.Price * Amount;
            Weight = Product.Weight * Amount;
        }
    }
}