using System;

// Батьківський клас "Рівняння"
public class Equation
{
    protected double[] coefficients;  // Масив коефіцієнтів

    // Конструктор класу, приймає коефіцієнти рівняння
    public Equation(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    // Віртуальний метод для виведення коефіцієнтів рівняння
    public virtual void DisplayCoefficients()
    {
        Console.Write("Coefficients: ");
        foreach (double coefficient in coefficients)
        {
            Console.Write($"{coefficient} ");
        }
        Console.WriteLine();
    }

    // Віртуальний метод для перевірки, чи задовольняє число рівнянню
    public virtual bool SatisfiesEquation(double num)
    {
        double result = 0;
        int power = coefficients.Length - 1;

        // Обчислення значення рівняння для заданого числа
        foreach (double coefficient in coefficients)
        {
            result += coefficient * Math.Pow(num, power);
            power--;
        }

        // Перевірка, чи рівно нулю
        return result == 0;
    }
}

// Похідний клас "Квадратне рівняння"
public class QuadraticEquation : Equation
{
    // Конструктор, викликає конструктор батьківського класу
    public QuadraticEquation(params double[] coefficients) : base(coefficients)
    {
    }

    // Перевизначений віртуальний метод для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine("Quadratic " + base.ToString());
        base.DisplayCoefficients();
    }

    // Метод для знаходження коренів квадратного рівняння
    public string FindRoots()
    {
        double discriminant = Math.Pow(coefficients[1], 2) - 4 * coefficients[0] * coefficients[2];

        if (discriminant < 0)
            return "No real roots";
        else if (discriminant == 0)
        {
            double root = -coefficients[1] / (2 * coefficients[0]);
            return $"Single real root: {root}";
        }
        else
        {
            double root1 = (-coefficients[1] + Math.Sqrt(discriminant)) / (2 * coefficients[0]);
            double root2 = (-coefficients[1] - Math.Sqrt(discriminant)) / (2 * coefficients[0]);
            return $"Two real roots: {root1}, {root2}";
        }
    }
}

// Похідний клас "Кубічне рівняння"
public class CubicEquation : Equation
{
    // Конструктор, викликає конструктор батьківського класу
    public CubicEquation(params double[] coefficients) : base(coefficients)
    {
    }

    // Перевизначений віртуальний метод для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine("Cubic " + base.ToString());
        base.DisplayCoefficients();
    }
}

// Головний клас програми
public class Program
{
    // Головний метод програми
    static void Main()
    {
        // Створення об'єкта квадратного рівняння через метод CreateEquation
        Equation equation1 = CreateEquation(1, -3, 2);
        equation1.DisplayCoefficients();
        Console.WriteLine(equation1.SatisfiesEquation(1));

        // Створення об'єкта кубічного рівняння через метод CreateEquation
        Equation equation2 = CreateEquation(1, -6, 11, -6);
        equation2.DisplayCoefficients();

        // Перевірка, чи об'єкт є екземпляром класу QuadraticEquation перед кастом
        if (equation2 is QuadraticEquation)
        {
            // Виклик методу FindRoots, оскільки об'єкт є QuadraticEquation
            Console.WriteLine(((QuadraticEquation)equation2).FindRoots());
        }
        else
        {
            Console.WriteLine("The equation is not quadratic.");
        }
    }

    // Метод для динамічного створення об'єктів
    static Equation CreateEquation(params double[] coefficients)
    {
        if (coefficients.Length == 3)
            return new QuadraticEquation(coefficients);
        else if (coefficients.Length == 4)
            return new CubicEquation(coefficients);

        // Виняток, якщо кількість коефіцієнтів не відповідає жодному з рівнянь
        throw new ArgumentException("Invalid number of coefficients for equation");
    }
}