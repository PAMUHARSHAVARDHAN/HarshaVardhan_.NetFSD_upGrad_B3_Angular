using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        // Validate Sales Input
        double sales;
        while (true)
        {
            Console.Write("Enter Monthly Sales Amount: ");
            if (double.TryParse(Console.ReadLine(), out sales) && sales >= 0)
                break;
            Console.WriteLine("Invalid sales amount! Try again.");
        }

        // Validate Rating Input
        int rating;
        while (true)
        {
            Console.Write("Enter Customer Rating (1-5): ");
            if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
                break;
            Console.WriteLine("Invalid rating! Enter between 1 and 5.");
        }

        // Get Tuple result
        var result = GetPerformanceData(sales, rating);

        // Pattern Matching
        string performance = result switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        // Display Output
        Console.WriteLine("\n----- Employee Performance -----");
        Console.WriteLine($"Employee Name: {name}");
        Console.WriteLine($"Sales Amount: {result.sales}");
        Console.WriteLine($"Rating: {result.rating}");
        Console.WriteLine($"Performance: {performance}");
    }

    // Method returning Tuple
    static (double sales, int rating) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }
}