namespace PROG2070Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(101, "Laptop", 999.99m, 10);

            Console.WriteLine($"Product: {product1.ProdName}, Price: {product1.ItemPrice}, Stock: {product1.StockAmount}");

            product1.increaseStock(5);
            Console.WriteLine($"Stock after increase: {product1.StockAmount}");

            product1.DecreaseStock(3);
            Console.WriteLine($"Stock after decrease: {product1.StockAmount}");
        }
    }
}
