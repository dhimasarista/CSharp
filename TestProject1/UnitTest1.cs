// UnitTest1.cs
namespace CSharp.Tests;

[TestFixture]
public class UnitTest1
{
    [Test]
    public void TestMethod1()
    {
        // Arrange
        int a = 5;
        int b = 10;

        // Act
        int result = a + b;

        // Assert
        Assert.AreEqual(15, result);
    }
}
