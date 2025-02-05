namespace PROG2070Assignment2
{
    public class Product
    {
        private int prodId;
        private string prodName;
        private decimal itemPrice;
        private int stockAmount;

        public int ProdId { get => prodId; set => prodId = value; }
        public string ProdName { get => prodName; set => prodName = value; }
        public decimal ItemPrice { get => itemPrice; set => itemPrice = value; }
        public int StockAmount { get => stockAmount; set => stockAmount = value; }

        public Product(int prodId, string prodName, decimal itemPrice, int stockAmount)
        {
            this.prodId = prodId;
            this.prodName = prodName;
            this.itemPrice = itemPrice;
            this.stockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            this.StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            this.stockAmount -= amount;
        }
    }
}