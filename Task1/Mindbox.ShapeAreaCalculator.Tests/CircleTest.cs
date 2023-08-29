using Minbox.ShapeAreaCalculator.Exceptions;
using Minbox.ShapeAreaCalculator.Figures;

namespace Mindbox.ShapeAreaCalculator.Tests;

public class CircleTest
{
    [Fact]
    public void ShouldCreateCircleWithRadius()
    {
        var expectedRadius = 10;

        var circle = new Circle(expectedRadius);
        var actualRadius = circle.Radius;

        Assert.Equal(expectedRadius, actualRadius);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(0)]
    public void ShouldNotCreateCircleWithInvalidRadius(double invalidRadius)
    {
        Assert.Throws<InvalidSideSizeException>(() => new Circle(invalidRadius));
    }

    [Fact]
    public void ShouldGetArea()
    {
        var expectedArea = 314.15926535897933d;
        var radius = 10;
        var circle = new Circle(radius);

        var actualArea = circle.GetArea();

        Assert.Equal(expectedArea, actualArea);
    }

    [Fact]
    public void ShouldToString()
    {
        var expectedString = "Круг: R = 10.";
        var radius = 10;
        var circle = new Circle(radius);

        var actualString = circle.ToString();

        Assert.Equal(expectedString, actualString);
    }
}