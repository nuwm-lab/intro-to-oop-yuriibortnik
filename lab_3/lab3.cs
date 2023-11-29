public class Program
{
    // Initialize void CalculateSums
    public static double[] CalculateSums(int a)
    {
        double[] sums = new double[3];
        for (int i = 1; i <= 3; i++)
        {
            sums[i - 1] = a / (i * (i + 1.0));
        }
        return sums;
    }

    public static void Main()
    {
        
        Console.Write("Enter an integer (a): ");
        if (int.TryParse(Console.ReadLine(), out int a))
        {
            double[] sums = CalculateSums(a);

            // Find the index of the maximum sum
            int maxIndex = Array.IndexOf(sums, sums.Max()) + 1;

            Console.WriteLine($"Sums: {string.Join(", ", sums)}");
            Console.WriteLine($"Object with the largest sum: {maxIndex}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    
}
