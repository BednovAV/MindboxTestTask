namespace Minbox.ShapeAreaCalculator.Exceptions;

public class InvalidSideNameException : Exception
{
    public InvalidSideNameException()
        : base($"The name of the side can not be empty") { }
}
