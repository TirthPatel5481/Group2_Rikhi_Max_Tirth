using ECommerceApp;
using NUnit.Framework;

namespace Group2_Rikhi_Max_Tirth_Tests
{
    public class Tests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product(100, "Laptop", 1000, 10);
        }

        // Testing Attributes
        [Test]
        public void Product_ValidProdID_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdID, Is.EqualTo(100));
        }

        [Test]
        public void Product_ValidProdName_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ProdName, Is.EqualTo("Laptop"));
        }

        [Test]
        public void Product_ValidItemPrice_ShouldBeSetCorrectly()
        {
            Assert.That(_product.ItemPrice, Is.EqualTo(1000m));
        }

        [Test]
        public void Product_ValidStockAmount_ShouldBeSetCorrectly()
        {
            Assert.That(_product.StockAmount, Is.EqualTo(10));
        }

        [Test]
        public void Product_NegativeStockAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(101, "Phone", 500m, -5));
        }

        [Test]
        public void Product_NegativePrice_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(102, "Tablet", -100m, 10));
        }

        // Testing Stock Increase
        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            // Arrange
            int initialStock = _product.StockAmount;
            int increaseAmount = 5;

            // Act
            _product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(_product.StockAmount, Is.EqualTo(initialStock + increaseAmount));
        }

        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            // Arrange
            int invalidIncreaseAmount = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(invalidIncreaseAmount));
        }

        [Test]
        public void IncreaseStock_ZeroAmount_ShouldNotChangeStock()
        {
            // Arrange
            int initialStock = _product.StockAmount;
            int zeroIncreaseAmount = 0;

            // Act
            _product.IncreaseStock(zeroIncreaseAmount);

            // Assert
            Assert.That(_product.StockAmount, Is.EqualTo(initialStock));
        }

        [Test]
        public void IncreaseStock_ExceedMaximumStock_ShouldThrowException()
        {
            // Arrange
            _product = new Product(100, "Laptop", 1000m, 499995); // Set stock close to the maximum limit
            int increaseAmount = 10; // This will exceed the maximum limit

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _product.IncreaseStock(increaseAmount));
        }

        [Test]
        public void IncreaseStock_LargeValidAmount_ShouldIncreaseStock()
        {
            // Arrange
            _product = new Product(100, "Laptop", 1000m, 100);
            int increaseAmount = 1000; 

            // Act
            _product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(_product.StockAmount, Is.EqualTo(1100));
        }

        [Test]
        public void IncreaseStock_AtMaximumStock_ShouldNotThrowException()
        {
            // Arrange
            _product = new Product(100, "Laptop", 1000m, 499990); // this will Set stock close to the maximum limit
            int increaseAmount = 10; 

            // Act & Assert
            Assert.DoesNotThrow(() => _product.IncreaseStock(increaseAmount));
            Assert.That(_product.StockAmount, Is.EqualTo(500000)); //this is to Verify stock is at the maximum limit
        }

        // Testing Stock Decrease
    }
}