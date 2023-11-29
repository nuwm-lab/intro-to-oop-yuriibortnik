public ﻿class QuadraticEquation
{
    public double b2, b1, b0;

    public QuadraticEquation(double b2, double b1, double b0)
    {
        this.b2 = b2;
        this.b1 = b1;
        this.b0 = b0;
    }

    public void DisplayCoefficients()
    {
        Console.WriteLine($"Coefficients: b2 = {b2}, b1 = {b1}, b0 = {b0}");
    }

    public bool SatisfiesEquation(double num)
    {
        double result = b2 * Math.Pow(num, 2) + b1 * num + b0;
        return result == 0;
    }

    public string FindRoots()
    {
        double discriminant = Math.Pow(b1, 2) - 4 * b2 * b0;

        if (discriminant < 0)
            return "No real roots";
        else if (discriminant == 0)
        {
            double root = -b1 / (2 * b2);
            return $"Single real root: {root}";
        }
        else
        {
            double root1 = (-b1 + Math.Sqrt(discriminant)) / (2 * b2);
            double root2 = (-b1 - Math.Sqrt(discriminant)) / (2 * b2);
            return $"Two real roots: {root1}, {root2}";
        }
    }
}

public class CubicEquation : QuadraticEquation
{
    private double b3;

    public CubicEquation(double b3, double b2, double b1, double b0) : base(b2, b1, b0)
    {
        this.b3 = b3;
    }

    public new void DisplayCoefficients()
    {
        Console.WriteLine($"Coefficients: b3 = {b3}, b2 = {base.b2}, b1 = {base.b1}, b0 = {base.b0}");
    }

    public new bool SatisfiesEquation(double num)
    {
        double result = b3 * Math.Pow(num, 3) + Convert.ToDouble(base.SatisfiesEquation(num));
        return result == 0;
    }
}

public class Program
{
    static void Main()
    {
        QuadraticEquation quadraticEq = new QuadraticEquation(1, -3, 2);
        quadraticEq.DisplayCoefficients();
        Console.WriteLine(quadraticEq.FindRoots());

        CubicEquation cubicEq = new CubicEquation(1, -6, 11, -6);
        cubicEq.DisplayCoefficients();
        Console.WriteLine(cubicEq.SatisfiesEquation(1));
    }
}
