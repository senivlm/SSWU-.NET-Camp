namespace HW1
{
    public class Product
    {
        private string _name;
        private double _price;
        private double _weight;

        public string Name { get => _name; }
        public double Price { get => _price;}
        public double Weight { get => _weight;}

        public Product(string name, double price, double weight)
        {
            _name = name;
            _price = price;
            _weight = weight;
        }
    }
}