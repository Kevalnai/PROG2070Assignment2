using PROG2070Assignment2;

namespace PROG2070Assignment2UnitTests
{
    public class ProductTest
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
        public void SetProdId_Input123_Valid()
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
        public void SetProdId_Input4_Invalid()
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
        public void SetProdId_Input50001_Invalid()
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
         * Verify that IncreaseStock method works correctly for valid inputs (stock: 500000, amount: 0)
         * - Kuolung Cheng
         */
        [Test]
        public void IncreaseStock_Input500000And0_Valid()
        {
            // Arrange
            int stock = 500000;
            int amount = 0;
            testProduct.StockAmount = stock;
            int expected = 500000;

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
            Assert.That(stock.StockAmount, Is.EqualTo(5)); // Stock should be 5 after the decrease.
        }

        /*
         * Testing that the decrease amount should not below minimum stock 
         * - KevalNai
         */
        [Test]
        public void DecreaseStock_InvalidAmount_ShouldNotBelowMinStock()
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
         *  Testing that the decrease amount should not exceed maximum stock 
         *  - Keval Nai
         */
        [Test]
        public void DecreaseStock_InvalidAmount_ShouldNotExceedMaxStock()
        {
            // Arrange
            var stock = new Product();  // Create a new product instance.
            stock.StockAmount = 500000;  // Set the initial stock amount to the maximum valid value.
            int amount = -10;  // Amount to decrease the stock by, which will make stock 500010 (exceed maximum 500000)

            // Act
            var actual = Assert.Throws<ArgumentException>(() => stock.DecreaseStock(amount));  // Decrease by -10, expecting exception

            // Assert 
            Assert.That(actual.Message, Does.Contain("Stock amount must be between 5 and 500000"));  // Verify exception message
        }

        /*
         * Testing the stock amount set to minimum limit (5) should be okay
         * - Keval Nai
         */
        [Test]
        public void SetStockAmount_MinimumValidPrice_ShouldSetStockAmountTo5()
        {
            // Arrange
            var product = new Product();  // Create a new product instance.

            // Act
            product.StockAmount = 5;  // Set the stock amount to the minimum valid value (5).

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(5));  // The stock amount should be exactly 5 after setting.
        }

        /*
         * Testing the check the item price set to minimum limit (5) should be okay
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
            Assert.That(product.ItemPrice, Is.EqualTo(5));  // The price should be exactly 5 after setting.
        }

        /*
         * Testing the item price set to maximum limit (5000) should be okay
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
            Assert.That(product.ItemPrice, Is.EqualTo(5000));  // The price should be exactly 5000 after setting.
        }

        /*
        * this test case check the item price (50) can be set successfully
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
         * this test case check the Stock Amount (50) can be set successfully
         * - Zixiao Zhou
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

        /*
         * Testing the stock amount set to maximum limit (500000) should be okay
         * - Zixiao Zhou
         */
        [Test]
        public void SetStockAmount_MaximumValidPrice_ShouldSetStockAmountTo500000()
        {
            // Arrange
            var product = new Product();

            // Act
            product.StockAmount = 500000;

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(500000));
        }

        /*
         * Testing that the increase amount should not below minimum stock 
         * - Zixiao Zhou
         */
        [Test]
        public void IncreaseStock_InvalidAmount_ShouldNotBelowMinStock()
        {
            // Arrange
            var stock = new Product();
            stock.StockAmount = 10;
            int amount = -15;

            // Act
            var actual = Assert.Throws<ArgumentException>(() => stock.IncreaseStock(amount));

            // Assert 
            Assert.That(actual.Message, Does.Contain("Stock amount must be between 5 and 500000"));
        }

        /*
         *  Testing that the increase amount should not exceed maximum stock 
         *  - Zixiao Zhou
         */
        [Test]
        public void IncreaseStock_InvalidAmount_ShouldNotExceedMaxStock()
        {
            // Arrange
            var stock = new Product();
            stock.StockAmount = 400000;
            int amount = 100001;

            // Act
            var actual = Assert.Throws<ArgumentException>(() => stock.IncreaseStock(amount));

            // Assert 
            Assert.That(actual.Message, Does.Contain("Stock amount must be between 5 and 500000"));
        }

        /*
         * Testing the valid decrease in the stock amount
         * - Zixiao Zhou
         * */
        [Test]
        public void DecreaseStock_Input5And0_Valid()
        {
            // Arrange
            int stock = 5;
            int amount = 0;
            testProduct.StockAmount = stock;
            int expected = 5;

            // Act
            testProduct.DecreaseStock(amount);
            int actual = testProduct.StockAmount;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
