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
         * Verify that setting a product ID (50001) above the minimum value (50000) will throw an exception
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
    }
}
