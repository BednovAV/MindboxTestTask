using Minbox.ShapeAreaCalculator.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace Minbox.ShapeAreaCalculator.Abstract;

public abstract class Shape
{
    private IDictionary<string, double> _sides;
    private Lazy<double> _area;

    public Shape(params (string sideName, double sideSize)[] sides)
    {
        ValidateSides(sides);

        _sides = sides.ToDictionary(s => s.sideName, s => s.sideSize);
        _area = new Lazy<double>(GetAreaInternal);
    }

    private static void ValidateSides((string sideName, double sideSize)[] sides)
    {
        if (sides.Any(s => string.IsNullOrWhiteSpace(s.sideName)))
            throw new InvalidSideNameException();

        var invalidSide = sides.FirstOrDefault(s => s.sideSize <= 0);
        if (invalidSide != default)
            throw new InvalidSideSizeException(invalidSide.sideName);
    }

    protected abstract double GetAreaInternal();

    protected abstract string Name { get; }

    protected double GetSideOrZero(string sideName) =>
        _sides.TryGetValue(sideName, out var sideSize)
        ? sideSize
        : 0d;

    protected (string sideName, double sideSize)[] GetSides()
        => _sides.Select(s => (s.Key, s.Value)).ToArray();

    /// <summary>
    /// Вычисление площади фигуры
    /// </summary>
    /// <returns>Площадь фигуры</returns>
    public double GetArea() => _area.Value;


    /// <summary>
    /// Строковое представление фигуры
    /// </summary>
    public override string ToString()
    {
        var sideStrings = _sides.Select(s => $"{s.Key} = {s.Value}").ToArray();
        return $"{Name}: {string.Join("; ", sideStrings)}.";
    }
}