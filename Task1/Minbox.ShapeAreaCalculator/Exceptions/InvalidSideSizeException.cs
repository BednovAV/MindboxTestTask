namespace Minbox.ShapeAreaCalculator.Exceptions;

public class InvalidSideSizeException : Exception
{
    public InvalidSideSizeException(string sideName)
        : base($"Side {sideName} size must be greather than zero") { }
}
