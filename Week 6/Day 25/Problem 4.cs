//Level - 2 Problem 4: Asynchronous Order Processing System
//Scenario:
// An e-commerce system processes customer orders. Each order requires multiple steps such as payment verification, inventory check, and order confirmation. These steps involve delays and should be handled asynchronously.

//Requirements:
// -Create asynchronous methods:
//   -VerifyPaymentAsync()
//   - CheckInventoryAsync()
//   - ConfirmOrderAsync()
// - Simulate processing delays using Task.Delay().
// - Execute steps asynchronously while maintaining the logical order of operations.
//Technical Constraints:
// -Use async and await.
// - Use Task-based asynchronous methods.
// - Implement using a console application.

//Expectations:
// -Each processing step should run asynchronously.
// - The program should display messages indicating the progress of order processing.

//Learning Outcome:
// Students will understand how to design real-world workflows using asynchronous methods with async/await.

using System;
using System.Threading.Tasks;

class Program
{
    // Step 1: Verify Payment
    public static async Task<bool> VerifyPaymentAsync()
    {
        Console.WriteLine("Payment Verification Started...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Payment Verified ✅");
        return true;
    }

    // Step 2: Check Inventory
    public static async Task<bool> CheckInventoryAsync()
    {
        Console.WriteLine("Inventory Check Started...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Inventory Available ✅");
        return true;
    }

    // Step 3: Confirm Order
    public static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Order Confirmation Started...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Order Confirmed 🎉");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Processing Order...\n");

        // Step-by-step execution (logical order maintained)

        bool paymentStatus = await VerifyPaymentAsync();

        if (paymentStatus)
        {
            bool inventoryStatus = await CheckInventoryAsync();

            if (inventoryStatus)
            {
                await ConfirmOrderAsync();
            }
            else
            {
                Console.WriteLine("Order Failed ❌: Item Out of Stock");
            }
        }
        else
        {
            Console.WriteLine("Order Failed ❌: Payment Issue");
        }

        Console.WriteLine("\nOrder Processing Completed!");
    }
}

