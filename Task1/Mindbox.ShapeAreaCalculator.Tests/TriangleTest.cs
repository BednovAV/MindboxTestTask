using Minbox.ShapeAreaCalculator.Exceptions;
using Minbox.ShapeAreaCalculator.Figures;

namespace Mindbox.ShapeAreaCalculator.Tests;

public class TriangleTest
{
    [Fact]
    public void ShouldCreateTriangleWithSides()
    {
        var expectedSideA = 2;
        var expectedSideB = 4;
        var expectedSideC = 3;

        var triangle = new Triangle(expectedSideA, expectedSideB, expectedSideC);
        var actualSideA = triangle.SideA;
        var actualSideB = triangle.SideB;
        var actualSideC = triangle.SideC;

        Assert.Equal(expectedSideA, actualSideA);
        Assert.Equal(expectedSideB, actualSideB);
        Assert.Equal(expectedSideC, actualSideC);
    }

    [Theory]
    [InlineData(1, 2, 0)]
    [InlineData(2, 0, 1)]
    [InlineData(0, 1, 2)]
    [InlineData(1, 2, -1)]
    [InlineData(2, -1, 1)]
    [InlineData(-1, 1, 2)]
    public void ShouldNotCreateTriangleWithInvalidSide(
        double sideA,
        double sideB,
        double sideC)
    {
        Assert.Throws<InvalidSideSizeException>(() => new Triangle(sideA, sideB, sideC));
    }
    
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 1)]
    [InlineData(3, 1, 2)]
    public void ShouldNotCreateNotExsistingTriangle(
        double sideA,
        double sideB,
        double sideC)
    {
        Assert.Throws<TriangleNotExistException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Fact]
    public void ShouldGetArea()
    {
        var expectedArea = 2.9047375096555625d;
        var sideA = 2;
        var sideB = 4;
        var sideC = 3;
        var triangle = new Triangle(sideA, sideB, sideC);

        var actualArea = triangle.GetArea();

        Assert.Equal(expectedArea, actualArea);
    }
    
    [Fact]
    public void ShouldToString()
    {
        var expectedString = "Треугольник: A = 2; B = 4; C = 3.";
        var sideA = 2;
        var sideB = 4;
        var sideC = 3;
        var triangle = new Triangle(sideA, sideB, sideC);

        var actualString = triangle.ToString();

        Assert.Equal(expectedString, actualString);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 3, 4)]
    [InlineData(4, 5, 3)]
    public void ShouldIsRight(
        double sideA,
        double sideB,
        double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var actualIsRight = triangle.IsRight();

        Assert.True(actualIsRight);
    }

    [Theory]
    [InlineData(3, 4, 6)]
    [InlineData(6, 3, 4)]
    [InlineData(4, 6, 3)]
    public void ShouldNotIsRight(
    double sideA,
    double sideB,
    double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var actualIsRight = triangle.IsRight();

        Assert.False(actualIsRight);
    }
}
