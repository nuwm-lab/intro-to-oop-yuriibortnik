// Абстрактний клас для рівнянь
public abstract class Equation
{
    // Поля для коефіцієнтів рівнянь
    protected double[] coefficients;

    // Конструктор для ініціалізації коефіцієнтів
    public Equation(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    // Абстрактний метод для виведення коефіцієнтів
    public abstract void DisplayCoefficients();

    // Абстрактний метод для перевірки розв'язку
    public abstract bool IsSolution(double number);

    // Абстрактний метод для пошуку коренів рівняння
    public abstract void FindRoots();
}

// Клас для квадратного рівняння
public class QuadraticEquation : Equation
{
    // Конструктор для квадратного рівняння
    public QuadraticEquation(double b2, double b1, double b0) : base(b2, b1, b0)
    {
    }

    // Реалізація методу для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Quadratic Equation Coefficients: b2 = {coefficients[0]}, b1 = {coefficients[1]}, b0 = {coefficients[2]}");
    }

    // Реалізація методу для перевірки розв'язку
    public override bool IsSolution(double number)
    {
        double result = coefficients[0] * Math.Pow(number, 2) + coefficients[1] * number + coefficients[2];
        return result == 0;
    }

    // Реалізація методу для пошуку коренів квадратного рівняння
    public override void FindRoots()
    {
        // Реалізація пошуку коренів
        // ...
    }
}

// Клас для кубічного рівняння
public class CubicEquation : Equation
{
    // Конструктор для кубічного рівняння
    public CubicEquation(double b3, double b2, double b1, double b0) : base(b3, b2, b1, b0)
    {
    }

    // Реалізація методу для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Cubic Equation Coefficients: b3 = {coefficients[0]}, b2 = {coefficients[1]}, b1 = {coefficients[2]}, b0 = {coefficients[3]}");
    }

    // Реалізація методу для перевірки розв'язку
    public override bool IsSolution(double number)
    {
        double result = coefficients[0] * Math.Pow(number, 3) + coefficients[1] * Math.Pow(number, 2) + coefficients[2] * number + coefficients[3];
        return result == 0;
    }

    // Реалізація методу для пошуку коренів кубічного рівняння
    public override void FindRoots()
    {
        // Реалізація пошуку коренів
        // ...
    }
}

// Клас Program для демонстрації роботи класів
public class Program
{
    static void Main()
    {
        // Створення об'єкта класу "Квадратне рівняння"
        Equation quadraticEquation = new QuadraticEquation(1, -3, 2);

        // Виклик методів
        quadraticEquation.DisplayCoefficients();
        double numberToCheck = 1;
        Console.WriteLine($"Is {numberToCheck} a solution? {quadraticEquation.IsSolution(numberToCheck)}");
        quadraticEquation.FindRoots();

        // Створення об'єкта класу "Кубічне рівняння"
        Equation cubicEquation = new CubicEquation(1, -3, 3, -1);

        // Виклик методів
        cubicEquation.DisplayCoefficients();
        double numberToCheckCubic = 1;
        Console.WriteLine($"Is {numberToCheckCubic} a solution? {cubicEquation.IsSolution(numberToCheckCubic)}");
        cubicEquation.FindRoots();
    }
}
