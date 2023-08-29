using Minbox.ShapeAreaCalculator.Abstract;
using Minbox.ShapeAreaCalculator.Exceptions;
using Minbox.ShapeAreaCalculator.Extensions;

namespace Minbox.ShapeAreaCalculator.Figures;

public class Triangle : Shape
{
    private const string SideAName = "A";
    private const string SideBName = "B";
    private const string SideCName = "C";


    /// <summary>
    /// Сторона A
    /// </summary>
    public double SideA => GetSideOrZero(SideAName);

    /// <summary>
    /// Сторона B
    /// </summary>
    public double SideB => GetSideOrZero(SideBName);

    /// <summary>
    /// Сторона C
    /// </summary>
    public double SideC => GetSideOrZero(SideCName);

    /// <summary>
    /// Создается экзепляр треугольника
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    public Triangle(double sideA, double sideB, double sideC)
        : base((SideAName, sideA),(SideBName, sideB),(SideCName, sideC))
    {
        if (!IsTriangleExists(sideA, sideB, sideC))
            throw new TriangleNotExistException(sideA, sideB, sideC);
    }

    private bool IsTriangleExists(double sideA, double sideB, double sideC)
        => sideA + sideB > sideC
        && sideB + sideC > sideA
        && sideC + sideA > sideB;

    protected override string Name => "Треугольник";

    protected override double GetAreaInternal()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2;
        return double.Sqrt(semiPerimeter
            * (semiPerimeter - SideA)
            * (semiPerimeter - SideB)
            * (semiPerimeter - SideC));
    }

    /// <summary>
    /// Проверка на то, является ли треугольник прямоугольным
    /// </summary>
    /// <returns>True, если трегольник прямоугольный, в противном случае false</returns>
    public bool IsRight()
    {
        var orderedSides = GetSides().OrderBy(s => s.sideSize).Select(s => s.sideSize).ToArray();
        return orderedSides[0].Pow2() + orderedSides[1].Pow2() == orderedSides[2].Pow2();
    }
}
