using Minbox.ShapeAreaCalculator.Abstract;
using Minbox.ShapeAreaCalculator.Extensions;

namespace Minbox.ShapeAreaCalculator.Figures;

public class Circle : Shape
{
    private const string RadiusName = "R";

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius => GetSideOrZero(RadiusName);

    /// <summary>
    /// Создается экзепляр круга
    /// </summary>
    /// <param name="radius">Радиус</param>
    public Circle(double radius)
        : base((RadiusName, radius)) { }

    protected override string Name => "Круг";

    protected override double GetAreaInternal()
        => double.Pi * Radius.Pow2();
}
