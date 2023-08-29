namespace Minbox.ShapeAreaCalculator.Exceptions;

public class TriangleNotExistException : Exception
{
    public TriangleNotExistException(double sideA, double sideB, double sideC)
        : base($"Triangle with sides {sideA}, {sideB}, {sideC} does not exists!") { }
}
