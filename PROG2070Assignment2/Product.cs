namespace PROG2070Assignment2
{
    public class Product
    {
        private int prodId;
        private string prodName;
        private double itemPrice;
        private int stockAmount;

        /*
         * maximum and minimum values:
         * Product ID: 5 - 50000
         * Price: $5 - $5000
         * Stock: 5 - 500000
         */
        public int ProdId
        {
            get { return prodId; }

            set
            {
                if (value < 5 || value > 50000)
                {
                    throw new ArgumentException("Product ID must be between 5 and 50000");
                }

                prodId = value;
            }
        }

        public string ProdName
        {
            get { return prodName; }

            set { prodName = value; }
        }

        public double ItemPrice
        {
            get { return itemPrice; }

            set
            {
                if (itemPrice < 5 || itemPrice > 5000)
                {
                    throw new ArgumentException("Item price must be between 5 and 5000");
                }

                itemPrice = value;
            }
        }
        public int StockAmount
        {
            get { return stockAmount; }

            set
            {
                if (value < 5 || value > 500000)
                {
                    throw new ArgumentException("Stock amount must be between 5 and 500000");
                }

                stockAmount = value;
            }
        }

        public Product()
        {
            prodId = 1000;
            prodName = "TestProduct";
            itemPrice = 1000.00;
            stockAmount = 1000;
        }

        public Product(int prodId, string prodName, double itemPrice, int stockAmount)
        {
            if (prodId < 5 || prodId > 50000)
            {
                throw new ArgumentException("Product ID must be between 5 and 50000");
            }

            if (itemPrice < 5 || itemPrice > 5000)
            {
                throw new ArgumentException("Item price must be between 5 and 5000");
            }

            if (stockAmount < 5 || stockAmount > 500000)
            {
                throw new ArgumentException("Stock amount must be between 5 and 500000");
            }

            this.prodId = prodId;
            this.prodName = prodName;
            this.itemPrice = itemPrice;
            this.stockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (StockAmount + amount > 500000)
            {
                throw new ArgumentException("Stock amount must be between 5 and 500000");
            }

            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (StockAmount - amount < 5)
            {
                throw new ArgumentException("Stock amount must be between 5 and 500000");
            }

            StockAmount -= amount;
        }


    }
}
