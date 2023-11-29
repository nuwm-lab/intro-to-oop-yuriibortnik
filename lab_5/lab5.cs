using System;

// Батьківський клас "Рівняння"
class Equation
{
    protected double[] Coefficients;  // Масив коефіцієнтів

    // Конструктор класу, приймає коефіцієнти рівняння
    public Equation(params double[] coefficients)
    {
        Coefficients = coefficients;
    }

    // Віртуальний метод для виведення коефіцієнтів рівняння
    public virtual void DisplayCoefficients()
    {
        Console.Write("Coefficients: ");
        Console.WriteLine(string.Join(", ", Coefficients));
    }

    // Віртуальний метод для перевірки, чи задовольняє число рівнянню
    public virtual bool SatisfiesEquation(double num)
    {
        double result = 0;
        int power = Coefficients.Length - 1;

        // Обчислення значення рівняння для заданого числа
        foreach (double coefficient in Coefficients)
        {
            result += coefficient * Math.Pow(num, power);
            power--;
        }

        // Перевірка, чи рівно нулю
        return result == 0;
    }
}

// Похідний клас "Квадратне рівняння"
class QuadraticEquation : Equation
{
    // Конструктор, викликає конструктор батьківського класу
    public QuadraticEquation(params double[] coefficients) : base(coefficients)
    {
    }

    // Перевизначений віртуальний метод для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine("Quadratic " + this.ToString());
        base.DisplayCoefficients();
    }

    // Метод для знаходження коренів квадратного рівняння
    public string FindRoots()
    {
        double discriminant = Math.Pow(Coefficients[1], 2) - 4 * Coefficients[0] * Coefficients[2];

        if (discriminant < 0)
            return "No real roots";
        else if (discriminant == 0)
        {
            double root = -Coefficients[1] / (2 * Coefficients[0]);
            return $"Single real root: {root}";
        }
        else
        {
            double root1 = (-Coefficients[1] + Math.Sqrt(discriminant)) / (2 * Coefficients[0]);
            double root2 = (-Coefficients[1] - Math.Sqrt(discriminant)) / (2 * Coefficients[0]);
            return $"Two real roots: {root1}, {root2}";
        }
    }
}

// Похідний клас "Кубічне рівняння"
class CubicEquation : Equation
{
    // Конструктор, викликає конструктор батьківського класу
    public CubicEquation(params double[] coefficients) : base(coefficients)
    {
    }

    // Перевизначений віртуальний метод для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine("Cubic " + this.ToString());
        base.DisplayCoefficients();
    }
}

// Головний клас програми
class Program
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
        if (equation2 is QuadraticEquation quadraticEquation)
        {
            // Виклик методу FindRoots, оскільки об'єкт є QuadraticEquation
            Console.WriteLine(quadraticEquation.FindRoots());
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
