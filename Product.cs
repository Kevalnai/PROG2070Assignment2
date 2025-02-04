using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2070Assignment2
{
    public class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            ProdId = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;

        }

        public void increaseStock(int amount)
        {
            if (amount > 0)
            {
                StockAmount += amount;
            }


        }
        public void DecreaseStock(int amount)
        {
            if (amount > 0 && amount <= StockAmount)
            {
                StockAmount -= amount;
            }
        }
    }
}