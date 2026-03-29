
//using System.Runtime.Intrinsics.X86;
//using static System.Net.Mime.MediaTypeNames;

//Level - 1 Problem 2: Debugging Incorrect Discount Calculation
//Scenario
//A retail application calculates the final price of products after applying a discount. Recently, users reported that the final price shown by the application is incorrect. The development team needs to debug the application to identify where the incorrect calculation is happening.
//Requirements
//•	Create a console application that calculates the final product price.
//•	The program should accept:
//o Product Name
//o	Product Price
//o	Discount Percentage
//•	The final price should be calculated using the formula:
//FinalPrice = Price − (Price × Discount / 100)
//•	Use debugging tools to verify that the calculation is correct.
//•	Place breakpoints and inspect variable values during execution.
//Technical Constraints
//•	Use Visual Studio Debugging Tools.
//•	Use breakpoints, step over, step into, and watch window.
//•	Implement the solution using a.NET console application.
//Expectations
//•	Students should run the program in debug mode.
//•	They should track variable values and confirm that the discount calculation is correct.
//•	If incorrect results appear, students should identify the faulty logic.
//Learning Outcome
//Students will learn how to:
//•	Use breakpoints effectively.
//•	Inspect variable values during program execution.
//•	Identify logical errors using debugging techniques.




using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Product Name:");
        string productName = Console.ReadLine();

        Console.WriteLine("Enter Product Price:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Discount Percentage:");
        double discount = Convert.ToDouble(Console.ReadLine());

        // 🔴 Place Breakpoint Here
        double discountAmount = price * discount / 100;

        // 🔴 Place Breakpoint Here
        double finalPrice = price - discountAmount;

        Console.WriteLine("\n----- BILL DETAILS -----");
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Original Price: {price}");
        Console.WriteLine($"Discount: {discount}%");
        Console.WriteLine($"Discount Amount: {discountAmount}");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}