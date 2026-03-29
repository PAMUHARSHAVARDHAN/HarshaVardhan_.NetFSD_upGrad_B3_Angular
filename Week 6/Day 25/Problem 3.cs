
//Level - 1 Problem 3:
//Scenario
//A financial application needs to process multiple reports simultaneously to reduce waiting time. Instead of executing tasks sequentially, the system should run them concurrently using C# Tasks so that reports are generated faster.
//Requirements
//1.Create three methods:
//a.GenerateSalesReport()
//b.GenerateInventoryReport()
//c.GenerateCustomerReport()
//2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
//3.Execute all three operations concurrently using Task.
//4.Display a message when each report starts and when it finishes.
//5.	Display a final message once all reports are completed.
//Technical Constraints
//•	Use Task class from System.Threading.Tasks.
//•	Use Task.Run() to execute methods.
//•	Use Task.WaitAll() or await Task.WhenAll() to wait for completion.
//•	The program must run in a Console Application.
//Expectations
//The program should start multiple report-generation tasks simultaneously and display completion messages for each report along with a final message once all tasks are completed.
//Learning Outcome
//Students will learn:
//•	How to create and run Tasks in C#
//•	How to execute multiple operations concurrently
//•	How to wait for multiple tasks to complete
//-------------------------------------------------------------------------------------------------------------
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Sales Report
    public static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started...");
        Thread.Sleep(3000); // Simulate processing time
        Console.WriteLine("Sales Report Completed!");
    }

    // Inventory Report
    public static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Started...");
        Thread.Sleep(4000); // Simulate processing time
        Console.WriteLine("Inventory Report Completed!");
    }

    // Customer Report
    public static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Started...");
        Thread.Sleep(2000); // Simulate processing time
        Console.WriteLine("Customer Report Completed!");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Report Generation...\n");

        // Run tasks concurrently
        Task task1 = Task.Run(() => GenerateSalesReport());
        Task task2 = Task.Run(() => GenerateInventoryReport());
        Task task3 = Task.Run(() => GenerateCustomerReport());

        // Wait for all tasks to complete
        Task.WaitAll(task1, task2, task3);

        Console.WriteLine("\nAll Reports Generated Successfully!");
    }
}






