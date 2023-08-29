using Minbox.ShapeAreaCalculator.Abstract;
using Minbox.ShapeAreaCalculator.Figures;

namespace Mindbox.ShapeAreaCalculator.Tests;

public class RuntimeTest
{
    [Theory]
    [InlineData("Круг")]
    [InlineData("Треугольник")]
    public void ShouldDefineShapeType(string figureType)
    {
        Shape? shape = null;
        double expectedArea = 0d;
        if (figureType == "Круг")
        {
            shape = new Circle(10);
            expectedArea = 314.15926535897933d;
        }
        else if (figureType == "Треугольник")
        {
            shape = new Triangle(2, 4, 3);
            expectedArea = 2.9047375096555625d;
        }

        var actualArea = shape?.GetArea();
        
        Assert.NotNull(actualArea);
        Assert.Equal(expectedArea, actualArea.Value);
    }
}
