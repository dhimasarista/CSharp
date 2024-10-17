using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 5;
            int b = 10;

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.AreEqual(15, result);
        }
    }

    public class Calculator
    {
        public int Add(int x, int y) => x + y;
    }
}
