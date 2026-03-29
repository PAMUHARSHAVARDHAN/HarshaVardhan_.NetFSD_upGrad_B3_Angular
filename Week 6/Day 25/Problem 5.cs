//using System.Runtime.Intrinsics.X86;
//using static System.Net.Mime.MediaTypeNames;

//Problem 5 Level-2: Application Tracing for Order Processing
//Scenario
//An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
//Requirements
//•	Create a console application that simulates order processing.
//•	The order processing should include the following steps:
//o Validate Order
//o	Process Payment
//o	Update Inventory
//o	Generate Invoice
//•	Use Trace class to log messages at each step of the process.
//•	Display trace messages showing the execution flow.
//Technical Constraints
//•	Use System.Diagnostics.Trace.
//•	Write trace messages using:
//o Trace.WriteLine()
//o Trace.TraceInformation()
//•	Configure a TextWriterTraceListener to store trace logs in a file.
//•	Implement the solution using .NET console application.
//Expectations
//•	The application should log messages for each stage of order processing.
//•	Trace logs should help developers identify where failures occur.
//•	The trace output should be stored in a log file.
//Learning Outcome
//Students will learn how to:
//•	Implement application tracing using System.Diagnostics.
//•	Monitor application flow using Trace listeners.
//•	Use trace logs to diagnose runtime issues in real-world applications.


using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Configure Trace Listener (log file)
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("OrderLog.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully!");
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"ERROR: {ex.Message}");
        }

        Console.WriteLine("Processing Completed. Check log file for details.");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validate Order - Started");

        // Simulate validation
        bool isValid = true;

        if (!isValid)
        {
            throw new Exception("Order validation failed!");
        }

        Trace.TraceInformation("Step 1: Validate Order - Completed");
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Process Payment - Started");

        // Simulate payment issue (change to false to test)
        bool paymentSuccess = true;

        if (!paymentSuccess)
        {
            throw new Exception("Payment processing failed!");
        }

        Trace.TraceInformation("Step 2: Payment Processed Successfully");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Update Inventory - Started");

        // Simulate inventory update
        bool inventoryUpdated = true;

        if (!inventoryUpdated)
        {
            throw new Exception("Inventory update failed!");
        }

        Trace.TraceInformation("Step 3: Inventory Updated");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generate Invoice - Started");

        // Simulate invoice generation
        Trace.TraceInformation("Step 4: Invoice Generated Successfully");
    }
}

