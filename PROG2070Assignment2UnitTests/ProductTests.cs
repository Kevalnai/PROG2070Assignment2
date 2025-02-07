using PROG2070Assignment2;

namespace PROG2070Assignment2UnitTests
{
    public class ProductTests
    {
        private Product testProduct;

        [SetUp]
        public void Setup()
        {
            testProduct = new Product();
        }

        /* 
         * Verify that a valid product ID (123) can be set successfully
         * - Kuolung Cheng
         */
        [Test]
        public void ProdId_Input123_Valid()
        {
            // Arrange
            int input = 123;
            int expected = 123;

            // Act
            testProduct.ProdId = input;
            int actual = testProduct.ProdId;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /* 
         * Verify that setting a product ID (4) below the minimum value (5) will throw an exception
         * - Kuolung Cheng
         */
        [Test]
        public void ProdId_Input4_Invalid()
        {
            // Arrange
            int input = 4;
            string expected = "Product ID must be between 5 and 50000";

            // Act
            var actual = Assert.Throws<ArgumentException>(() => testProduct.ProdId = input);

            // Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }

        /* 
         * Verify that setting a product ID (50001) above the maximum value (50000) will throw an exception
         * - Kuolung Cheng
         */
        [Test]
        public void ProdId_Input50001_Invalid()
        {
            // Arrange
            int input = 50001;
            string expected = "Product ID must be between 5 and 50000";

            // Act
            var actual = Assert.Throws<ArgumentException>(() => testProduct.ProdId = input);

            // Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }

        /* 
         * Verify that IncreaseStock method works correctly for valid inputs (stock: 123, amount: 456)
         * - Kuolung Cheng
         */
        [Test]
        public void IncreaseStock_Input123And456_Valid()
        {
            // Arrange
            int stock = 123;
            int amount = 456;
            testProduct.StockAmount = stock;
            int expected = 579;

            // Act
            testProduct.IncreaseStock(amount);
            int actual = testProduct.StockAmount;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /* 
         * Verify that IncreaseStock method works correctly for valid inputs (stock: 499999, amount: 1)
         * - Kuolung Cheng
         */
        [Test]
        public void IncreaseStock_Input499999And1_Valid()
        {
            // Arrange
            int stock = 499999;
            int amount = 1;
            testProduct.StockAmount = stock;
            int expected = 500000;

            // Act
            testProduct.IncreaseStock(amount);
            int actual = testProduct.StockAmount;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /* 
         * Verify that calling IncreaseStock method with invalid inputs (stock: 499999, amount: 10)
         * that increases stock beyond the maximum value (500000) will throw an exception
         * - Kuolung Cheng
         */
        [Test]
        public void IncreaseStock_Input499999And10_Invalid()
        {
            // Arrange
            int stock = 499999;
            int amount = 10;
            testProduct.StockAmount = stock;
            string expected = "Stock amount must be between 5 and 500000";

            // Act
            var actual = Assert.Throws<ArgumentException>(() => testProduct.IncreaseStock(amount));

            // Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }


        /*
         * Testing the valid decrease in the stock amount
         * - Keval Nai
         * */
        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            // Arrange
            var stock = new Product();  // Assume ProductStock has a StockAmount property.
            stock.StockAmount = 100; // Initial stock amount.

            // Act
            stock.DecreaseStock(95); // Decrease by 95.

            // Assert
            Assert.AreEqual(5, stock.StockAmount); // Stock should be 5 after the decrease.
        }
        /*
         * Testing the invalid input for the decrease method 
         * - KevalNai
         */
        [Test]
        public void DecreaseStock_InvalidAmount()
        {
            // Arrange
            var stock = new Product();
            stock.StockAmount = 10;  // Initial stock amount = 10
            int amount = 8;  // Amount to decrease the stock by, which will make stock 2 (below minimum 5)

            // Act
            var actual = Assert.Throws<ArgumentException>(() => stock.DecreaseStock(amount));  // Decrease by 8, expecting exception

            // Assert 
            Assert.That(actual.Message, Does.Contain("Stock amount must be between 5 and 500000"));  // Verify exception message
        }
        /*
         *  This test case checkthat the decrease amoutn should not exceed maximum stock 
         *  - Keval Nai
         */

        [Test]
        public void DecreaseStock_ValidAmount_ShouldNotExceedMaxStock()
        {
            // Arrange
            var stock = new Product();  // Create a new product instance.
            stock.StockAmount = 500000;  // Set the initial stock amount to the maximum valid value.

            // Act & Assert
            // No exception should be thrown when decreasing by 0 (just testing the boundary).
            stock.DecreaseStock(0);  // Stock should remain the same.
            Assert.AreEqual(500000, stock.StockAmount);  // Verify that the stock is still 500000.
        }


        /*
         * this test cases check the large amount of stock is decreased by the  very large number 
         * - Keval Nai
        */
        [Test]
        public void DecreaseStock_LargeAmount_ShouldDecreaseCorrectly()
        {
            // Arrange
            var stock = new Product();  // Create a new product instance.
            stock.StockAmount = 500000;  // Initial stock amount = 500000.

            // Act
            stock.DecreaseStock(50000);  // Decrease stock by 50,000.

            // Assert
            Assert.AreEqual(450000, stock.StockAmount);  // Stock should be 450,000 after the decrease.
        }


        /*
         * this test case the the check the item price set to minimum limit (5)
         * - Keval Nai
         */
        [Test]
        public void SetItemPrice_MinimumValidPrice_ShouldSetPriceTo5()
        {
            // Arrange
            var product = new Product();  // Create a new product instance.

            // Act
            product.ItemPrice = 5;  // Set the item price to the minimum valid value (5).

            // Assert
            Assert.AreEqual(5, product.ItemPrice);  // The price should be exactly 5 after setting.
        }
        /*
         * this test case the the check the item price set to maximum limit (5000)
         * - Keval Nai
         */
        [Test]
        public void SetItemPrice_MaximumValidPrice_ShouldSetPriceTo5000()
        {
            // Arrange
            var product = new Product();  // Create a new product instance.

            // Act
            product.ItemPrice = 5000;  // Set the item price to the maximum valid value (5000).

            // Assert
            Assert.AreEqual(5000, product.ItemPrice);  // The price should be exactly 5000 after setting.
        }



        /*
        * this test case the the check the item price(50) can be set successfully
        * -Zixiao Zhou
        */
        [Test]
        public void SetItemPrice_ValidPrice_Valid()
        {
            // Arrange
            double input = 50;
            double expected = 50;

            // Act
            testProduct.ItemPrice = input;
            double actual = testProduct.ItemPrice;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /* 
        * Verify that setting a Item Price (4) below the minimum value (5) will throw an exception
        * -Zixiao Zhou
        */
        [Test]
        public void SetItemPrice_Input4_Invalid()
        {
            // Arrange
            int input = 4;
            string expected = "Item Price must be between 5 and 5000";

            // Act
            var actual = Assert.Throws<ArgumentException>(() => testProduct.ItemPrice = input);

            // Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }

        /* 
         * Verify that setting a Item Price (5001) above the maximum value (5000) will throw an exception
         * - Zixiao Zhou
         */
        [Test]
        public void SetItemPrice_Input50001_Invalid()
        {
            // Arrange
            int input = 5001;
            string expected = "Item Price must be between 5 and 5000";

            // Act
            var actual = Assert.Throws<ArgumentException>(() => testProduct.ItemPrice = input);

            // Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }

        /*
         * this test case the the check the Product id set to minimum limit (5)
         * - Zixiao Zhou
         */
        [Test]
        public void SetProdId_MinimumValidId_ShouldSetPriceTo5()
        {
            // Arrange
            var product = new Product();  // Create a new product instance.

            // Act
            product.ProdId = 5;  // Set the id to the minimum valid value (5).

            // Assert
            Assert.AreEqual(5, product.ProdId);  // The id should be exactly 5 after setting.
        }
        /*
         *this test case the the check the Product id set to maximum limit (50000)
         * - Zixiao Zhou
         */
        [Test]
        public void SetProdId_MaximumValidId_ShouldSetPriceTo50000()
        {
            // Arrange
            var product = new Product();  // Create a new product instance.

            // Act
            product.ProdId = 50000;  // Set the item price to the maximum valid value (5000).

            // Assert
            Assert.AreEqual(5000, product.ProdId);  // The id should be exactly 5000 after setting.
        }

        /*
        * this test case the the check the Stock Amount(50) can be set successfully
        * -Zixiao Zhou
        */
        [Test]
        public void SetStockAmount_ValidAmount_ShouldSetAmount50()
        {
            // Arrange
            int input = 50;
            int expected = 50;

            // Act
            testProduct.StockAmount = input;
            double actual = testProduct.StockAmount;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
